using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService {

    commonclass1 clscon = new commonclass1();
    public AutoComplete () {

        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    //[WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public string[] SearchProposal(string prefixText)
    {
        DataTable dt = Utility.ReturnProposals(2, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Proposal not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchProposalNumber(string prefixText)
   {
        DataTable dt = Utility.ReturnProposals(3, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Proposal not Found !");
        }
        return Customer.ToArray();
        
    }

    [WebMethod]
    public string[] SearchProject(string prefixText)
    {
        DataTable dt = Utility.ReturnProjects(1, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Project not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchProjectNumber(string prefixText)
    {
        DataTable dt = Utility.ReturnProjects(2, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Project not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchPNumber(string prefixText)
    {         
        DataTable dt = Utility.ReturnPNumber(18, prefixText);
        System.Collections.Generic.List<string> PNumber = new System.Collections.Generic.List<string>();
        int i = 0;
        string FillPNumber = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                FillPNumber = Convert.ToString(dt.Rows[i]["ProposalID"]);
                PNumber.Add(FillPNumber);
            }
        }
        else
        {
            PNumber.Add("Proposal not Found !");
        }
        return PNumber.ToArray();
    }

    [WebMethod]
    public string[] SearchCustomer(string prefixText)
    {
        DataTable dt = Utility.ReturnCustomers(9, 0, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("No Customer Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchEmployee(string prefixText)
    {
        DataTable dt = Utility.GetSpecificEmployees(4,prefixText,0,0,0);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string EmployeeName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                EmployeeName = Convert.ToString(dt.Rows[i]["EmployeeName"]);
                Customer.Add(EmployeeName);
            }
        }
        else
        {
            Customer.Add("No Employee Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchTopography(string prefixText)
    {
        DataTable dt = Utility.GetSpecificTopography(7, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string TopographyName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                TopographyName = Convert.ToString(dt.Rows[i]["TopographyName"]);
                Customer.Add(TopographyName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchTopography_2011(string prefixText)
    {
        DataTable dt = Utility.GetSpecificTopography(8, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string TopographyName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                TopographyName = Convert.ToString(dt.Rows[i]["TopographyName"]);
                Customer.Add(TopographyName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchMorphology(string prefixText)
    {
        DataTable dt = Utility.GetSpecificMorphology(9, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string TopographyName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                TopographyName = Convert.ToString(dt.Rows[i]["MorphologyName"]);
                Customer.Add(TopographyName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchMorphology_2011(string prefixText)
    {
        DataTable dt = Utility.GetSpecificMorphology(10, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string TopographyName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                TopographyName = Convert.ToString(dt.Rows[i]["MorphologyName"]);
                Customer.Add(TopographyName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchFaculty(string prefixText)
    {
        DataTable dt = Utility.GetSpecificFaculty(7, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string TopographyName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                TopographyName = Convert.ToString(dt.Rows[i]["FacultyName"]);
                Customer.Add(TopographyName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchPrefix(string prefixText)
    {
        DataTable dt = new DataTable();
        clscon.Return_DT(dt, "SELECT * FROM tbPrefixMaster WHERE PrefixName LIKE '" + prefixText + "%'");
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string PrefixName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                PrefixName = Convert.ToString(dt.Rows[i]["PrefixName"]);
                Customer.Add(PrefixName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchSufix(string prefixText)
    {
        DataTable dt = new DataTable();
        clscon.Return_DT(dt, "SELECT * FROM tbSufixMaster WHERE SufixName LIKE '" + prefixText + "%'");
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string SufixName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                SufixName = Convert.ToString(dt.Rows[i]["SufixName"]);
                Customer.Add(SufixName);
            }
        }
        else
        {
            Customer.Add("Not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchPNumberOnly(string prefixText)
    {
        DataTable dt = Utility.ReturnProposals(3, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["PNumber"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Proposal not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchCADDYJobNumber(string prefixText)
    {
        DataTable dt = Utility.ReturnCADDYJobNo(1, prefixText);
        System.Collections.Generic.List<string> CaddyJobNumber = new System.Collections.Generic.List<string>();
        int i = 0;
        string CaddyJobNo = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CaddyJobNo = Convert.ToString(dt.Rows[i]["JobNo"]);
                CaddyJobNumber.Add(CaddyJobNo);
            }
        }
        else
        {
            CaddyJobNumber.Add("Job No not Found !");
        }
        return CaddyJobNumber.ToArray();
    }
    //SearchJobName
    [WebMethod]
    public string[] SearchCADDYJobName(string prefixText)
    {
        DataTable dt = Utility.ReturnCADDYJobName(1, prefixText);
        System.Collections.Generic.List<string> CaddyJobName = new System.Collections.Generic.List<string>();
        int i = 0;
        string CaddyJob = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CaddyJob = Convert.ToString(dt.Rows[i]["JobName"]);
                CaddyJobName.Add(CaddyJob);
            }
        }
        else
        {
            CaddyJobName.Add("Job Name not Found !");
        }
        return CaddyJobName.ToArray();
    }

    [WebMethod]
    public string[] SearchJobNumberOnly(string prefixText)
    {
        DataTable dt = Utility.ReturnProjects(27, prefixText);
        System.Collections.Generic.List<string> Jobs = new System.Collections.Generic.List<string>();
        int i = 0;
        string JobID = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                JobID = Convert.ToString(dt.Rows[i]["JobID"]);
                Jobs.Add(JobID.Trim());
            }
        }
        else
        {
            Jobs.Add("Project not Found !");
        }
        return Jobs.ToArray();
    }

    [WebMethod]
    public string[] SearchProjectNameAndPNumber(string prefixText)
    {
        DataTable dt = Utility.ReturnProposals(37, prefixText);
        System.Collections.Generic.List<string> Proposals = new System.Collections.Generic.List<string>();
        int i = 0;
        string PName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                PName = Convert.ToString(dt.Rows[i]["PName"]);
                Proposals.Add(PName);
            }
        }
        else
        {
            Proposals.Add("Proposal not Found !");
        }
        return Proposals.ToArray();
    }

    [WebMethod]
    public string[] SearchProjectNameAndJNumber(string prefixText)
    {
        DataTable dt = Utility.ReturnProposals(38, prefixText);
        System.Collections.Generic.List<string> Projects = new System.Collections.Generic.List<string>();
        int i = 0;
        string PName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                PName = Convert.ToString(dt.Rows[i]["JobName"]);
                Projects.Add(PName);
            }
        }
        else
        {
            Projects.Add("Project not Found !");
        }
        return Projects.ToArray();
    }
    [WebMethod]
    public string[] SearchFabJob(string prefixText)
    {
        DataTable dt = Utility.ReturnFabJobDetail(12, prefixText);
        System.Collections.Generic.List<string> Projects = new System.Collections.Generic.List<string>();
        int i = 0;
        string JobName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                JobName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Projects.Add(JobName);
            }
        }
        else
        {
            Projects.Add("Project not Found !");
        }
        return Projects.ToArray();
    }

    [WebMethod]
    public string[] SearchITWProject(string prefixText)
    {
        DataTable dt = Utility.ReturnITWProjects(2, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Project not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchITWJobID(string prefixText)
    {
        DataTable dt = Utility.ReturnITWProjects(1, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Project not Found !");
        }
        return Customer.ToArray();
    }

    [WebMethod]
    public string[] SearchITWJob(string prefixText)
    {
        DataTable dt = Utility.ReturnITWProjectParts(1, prefixText);
        System.Collections.Generic.List<string> Customer = new System.Collections.Generic.List<string>();
        int i = 0;
        string CustomerName = null;
        if (dt.Rows.Count > 0)
        {
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                CustomerName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                Customer.Add(CustomerName);
            }
        }
        else
        {
            Customer.Add("Project not Found !");
        }
        return Customer.ToArray();
    }
}