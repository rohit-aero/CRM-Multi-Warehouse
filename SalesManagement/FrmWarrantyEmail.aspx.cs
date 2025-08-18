using System;
using System.Net.Mail;
using System.Text;
using System.Data;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class Transactions_FrmWarrantyEmail : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    // Page load event
    MailAddress from = new MailAddress(Utility.Email(), Utility.EmailDisplayName());
    //MailAddress to = new MailAddress("customercare@aero-werks.com", "Customer Care");
    MailAddress to = new MailAddress("aeroit@aero-werks.com", "Customer Care");
    MailAddress cc = new MailAddress("aeroit@aero-werks.com", "Rohit Kumar");
    string UserName = "aerowerksindia@gmail.com";
    string Password = "Aero@123";
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox. If you have questions please go to https://www.aero-werks.com/contact-us]";
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SendEmail();
            SendNotifications();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="Subject"></param>
    private void Send_Email(String Message, String Subject)
    {
        MailMessage message = new MailMessage(from, to);
        string mailbody = Message;
        message.CC.Add(cc);
        message.Subject = Subject;
        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
        System.Net.NetworkCredential basicCredential1 = new
        System.Net.NetworkCredential(UserName, Password);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = basicCredential1;
        client.Send(message);
        Message = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>
    private void SendEmail()
    {
        try
        {          
            string Message = string.Empty;
            string Subject = string.Empty;
            DataTable dt = new DataTable();
            cls.Return_DT(dt, "Get_Warranty");
            if (dt.Rows.Count > 0)
            {
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Message += "<p>Hi Team,</p><p>Here are Project details where Warranty is going to expire</p><ul>";
                    Message += "<li><strong>Job ID : </strong>"+ dt.Rows[i]["JobID"].ToString() + "</li>";
                    Message += "<li><strong>Project Name : </strong>" + dt.Rows[i]["CompanyName"].ToString() + "</li>";
                    Message += "<li><strong>Ship Date : </strong>" + dt.Rows[i]["ShipToArriveDate"].ToString() + "</li>";
                    Message += "<li><strong>Install Date : </strong>" + dt.Rows[i]["InstallDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty Start Date : </strong>" + dt.Rows[i]["WarrantyStartDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty End Date : </strong>" + dt.Rows[i]["WarrantyEndDate"].ToString() + "</li>";
                    Message += "<li><strong>Installation By : </strong>" + dt.Rows[i]["Desc"].ToString() + "</li>";
                    Message += "<li><strong>Dealer : </strong>" + dt.Rows[i]["Dealer"].ToString() + "</li>";
                    Message += "<li><strong>Sales Rep : </strong>" + dt.Rows[i]["DestRep"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Type : </strong>" + dt.Rows[i]["ConveyorType"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Model : </strong>" + dt.Rows[i]["ModelDescription"].ToString() + "</li>";
                    Message += "<li><strong>Net Equipment Price : </strong>" + dt.Rows[i]["NetEqPrice"].ToString() + "</li>";
                    Message += "</ul><p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p>";
                    Send_Email(Message, dt.Rows[i]["ProjectName"].ToString());
                    Message = "";
                    //MailMessage message = new MailMessage(from, to);
                    //string mailbody = Message;                  
                    //message.CC.Add(cc);
                    //message.Subject = dt.Rows[i]["ProjectName"].ToString();
                    //message.Body = mailbody;
                    //message.BodyEncoding = Encoding.UTF8;
                    //message.IsBodyHtml = true;                    
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                    //System.Net.NetworkCredential basicCredential1 = new
                    //System.Net.NetworkCredential(UserName, Password);
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    //client.Send(message);
                }
             }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void SendNotifications()
    {
        try
        {          
            string Message = string.Empty;
            string Subject = string.Empty;
            DataSet ds = new DataSet();
            cls.Return_DS(ds, "[dbo].[Send_Notification]");
            //Released and ShipToArrive date exsists but Ship Date not Entered
            if (ds.Tables[0].Rows.Count > 0)
            {               
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Message += "<p>Hi Team,</p><p>Here are Project details where Released and ShipToArrive date exist but Ship Date not Entered</p><blockquote><ul>";
                    Message += "<li><strong>Job ID : </strong>" + ds.Tables[0].Rows[i]["JobID"].ToString() + "</li>";
                    Message += "<li><strong>Project Name : </strong>" + ds.Tables[0].Rows[i]["ProjectName"].ToString() + "</li>";
                    Message += "<li><strong>Release Date : </strong>" + ds.Tables[0].Rows[i]["ReleaseDate"].ToString() + "</li>";
                    Message += "<li><strong>Ship to Arrive Date : </strong>" + ds.Tables[0].Rows[i]["ShipToArriveDate"].ToString() + "</li>";
                    Message += "<li><strong>Install Date : </strong>" + ds.Tables[0].Rows[i]["InstallDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty Start Date : </strong>" + ds.Tables[0].Rows[i]["WarrantyStartDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty End Date : </strong>" + ds.Tables[0].Rows[i]["WarrantyEndDate"].ToString() + "</li>";
                    Message += "<li><strong>Installation By : </strong>" + ds.Tables[0].Rows[i]["Desc"].ToString() + "</li>";
                    Message += "<li><strong>Dealer : </strong>" + ds.Tables[0].Rows[i]["Dealer"].ToString() + "</li>";
                    Message += "<li><strong>Sales Rep : </strong>" + ds.Tables[0].Rows[i]["DestRep"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Type : </strong>" + ds.Tables[0].Rows[i]["ConveyorType"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Model : </strong>" + ds.Tables[0].Rows[i]["ModelDescription"].ToString() + "</li>";

                    Message += "<li><strong>Net Equipment Price : </strong>" + ds.Tables[0].Rows[i]["NetEqPrice"].ToString() + "</li>";
                    Message += "</blockquote></ul><p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>"+ Do_Not_Reply + "</u></span></span></span></p>";
                    Send_Email(Message, ds.Tables[0].Rows[i]["ProjectName"].ToString());
                    Message = "";
                    //MailMessage message = new MailMessage(from, to);
                    //string mailbody = Message;                   
                    //message.CC.Add(cc);
                    //message.Subject = ds.Tables[0].Rows[i]["ProjectName"].ToString();
                    //message.Body = mailbody;
                    //message.BodyEncoding = Encoding.UTF8;
                    //message.IsBodyHtml = true;
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
                    //System.Net.NetworkCredential basicCredential1 = new
                    //System.Net.NetworkCredential(UserName, Password);
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    //client.Send(message);
                    //Message = string.Empty;
                }

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
               
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Message += "<p>Hi Team,</p><p>Here are Project details where Ship Date exist but Install Date not Entered</p><ul>";
                    Message += "<li><strong>Job ID : </strong>" + ds.Tables[1].Rows[i]["JobID"].ToString() + "</li>";
                    Message += "<li><strong>Project Name : </strong>" + ds.Tables[1].Rows[i]["ProjectName"].ToString() + "</li>";
                    Message += "<li><strong>Release Date : </strong>" + ds.Tables[1].Rows[i]["ReleaseDate"].ToString() + "</li>";
                    Message += "<li><strong>Ship to Arrive Date : </strong>" + ds.Tables[1].Rows[i]["ShipToArriveDate"].ToString() + "</li>";
                    Message += "<li><strong>Install Date : </strong>" + ds.Tables[1].Rows[i]["InstallDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty Start Date : </strong>" + ds.Tables[1].Rows[i]["WarrantyStartDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty End Date : </strong>" + ds.Tables[1].Rows[i]["WarrantyEndDate"].ToString() + "</li>";
                    Message += "<li><strong>Installation By : </strong>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</li>";
                    Message += "<li><strong>Dealer : </strong>" + ds.Tables[1].Rows[i]["Dealer"].ToString() + "</li>";
                    Message += "<li><strong>Sales Rep : </strong>" + ds.Tables[1].Rows[i]["DestRep"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Type : </strong>" + ds.Tables[1].Rows[i]["ConveyorType"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Model : </strong>" + ds.Tables[1].Rows[i]["ModelDescription"].ToString() + "</li>";
                    Message += "<li><strong>Net Equipment Price : </strong>" + ds.Tables[1].Rows[i]["NetEqPrice"].ToString() + "</li>";
                    Message += "</ul><p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p>";
                    Send_Email(Message, ds.Tables[1].Rows[i]["ProjectName"].ToString());
                    Message = "";
                    //MailMessage message = new MailMessage(from, to);
                    //string mailbody = Message;
                    //message.CC.Add(cc);
                    //message.Subject = ds.Tables[1].Rows[i]["ProjectName"].ToString();
                    //message.Body = mailbody;
                    //message.BodyEncoding = Encoding.UTF8;
                    //message.IsBodyHtml = true;
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                    //System.Net.NetworkCredential basicCredential1 = new
                    //System.Net.NetworkCredential(UserName, Password);
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    //client.Send(message);
                    //Message = string.Empty;
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
               
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    Message += "<p>Hi Team,</p><p>Here are Project details where Install Date exist but Warranty Start Date not Entered</p><ul>";
                    Message += "<li><strong>Job ID : </strong>" + ds.Tables[2].Rows[i]["JobID"].ToString() + "</li>";
                    Message += "<li><strong>Project Name : </strong>" + ds.Tables[2].Rows[i]["ProjectName"].ToString() + "</li>";
                    Message += "<li><strong>Release Date : </strong>" + ds.Tables[2].Rows[i]["ReleaseDate"].ToString() + "</li>";
                    Message += "<li><strong>Ship to Arrive Date : </strong>" + ds.Tables[2].Rows[i]["ShipToArriveDate"].ToString() + "</li>";
                    Message += "<li><strong>Install Date : </strong>" + ds.Tables[2].Rows[i]["InstallDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty Start Date : </strong>" + ds.Tables[2].Rows[i]["WarrantyStartDate"].ToString() + "</li>";
                    Message += "<li><strong>Warranty End Date : </strong>" + ds.Tables[2].Rows[i]["WarrantyEndDate"].ToString() + "</li>";
                    Message += "<li><strong>Installation By : </strong>" + ds.Tables[2].Rows[i]["Desc"].ToString() + "</li>";
                    Message += "<li><strong>Dealer : </strong>" + ds.Tables[2].Rows[i]["Dealer"].ToString() + "</li>";
                    Message += "<li><strong>Sales Rep : </strong>" + ds.Tables[2].Rows[i]["DestRep"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Type : </strong>" + ds.Tables[2].Rows[i]["ConveyorType"].ToString() + "</li>";
                    Message += "<li><strong>Conveyor Model : </strong>" + ds.Tables[2].Rows[i]["ModelDescription"].ToString() + "</li>";
                    Message += "<li><strong>Net Equipment Price : </strong>" + ds.Tables[2].Rows[i]["NetEqPrice"].ToString() + "</li>";
                    Message += "</ul><p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p>";
                    Send_Email(Message, ds.Tables[2].Rows[i]["ProjectName"].ToString());
                    Message = "";
                    //MailMessage message = new MailMessage(from, to);
                    //string mailbody = Message;
                    //message.CC.Add(cc);
                    //message.Subject = ds.Tables[2].Rows[i]["ProjectName"].ToString();
                    //message.Body = mailbody;
                    //message.BodyEncoding = Encoding.UTF8;
                    //message.IsBodyHtml = true;
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                    //System.Net.NetworkCredential basicCredential1 = new
                    //System.Net.NetworkCredential(UserName, Password);
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    //client.Send(message);
                    //Message = string.Empty;
                }
            }
            //Utility.ShowMessage(this, "Please check Inbox !!");
            Utility.ShowMessage_Error(Page, "Please check Inbox !!");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}