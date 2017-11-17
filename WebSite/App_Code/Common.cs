using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    String SENDER = "MAT_HAI_YEN";
    String CAMPAIGN_NAME = "member card";


    public String SMSSend(String phoneNumber, String content, int type, String sender, String campaign_name)
    {
        SpeedSMSAPI.SpeedSMSAPI api = new SpeedSMSAPI.SpeedSMSAPI("BxPXL41QTmwWu6iSwLFxBxmuXNPqUgOl");
        String userInfo = api.getUserInfo();
        String[] phones = new String[] {phoneNumber};
        String response = api.sendSMS(phones, content, type, sender, campaign_name);       
        return response;
    }

    public void SendSMSAPI(Object PhoneAndContent)
    {
        string[] SMSPara;

        SMSPara = PhoneAndContent.ToString().Split('~');

        SpeedSMSAPI.SpeedSMSAPI api = new SpeedSMSAPI.SpeedSMSAPI();
        String userInfo = api.getUserInfo();
        String response = api.sendSMS(SMSPara[0], SMSPara[1], SpeedSMSAPI.SpeedSMSAPI.TYPE_BRANDNAME, SENDER, CAMPAIGN_NAME);

    }

    public void SendEmail(Object email)
    {        
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new System.Net.NetworkCredential("haiyeneyegroup@gmail.com", "HYEG!@#$%^2017");
        smtpClient.Timeout = 30000;       
        smtpClient.Send((MailMessage)email);                
    }

    public String SMSSendOpenCard(String phoneNumber, String Card_Code, String AccessCode)
    {
        String para;
        String content = "Chuc mung thanh vien moi:\\nMa thanh vien: " + Card_Code + ".\\nMat khau: " + AccessCode + ".\\nVui long thay doi mat khau sau khi dang nhap.\\nTran trong";
        para = phoneNumber + "~" + content;
        ParameterizedThreadStart Tref = new ParameterizedThreadStart(SendSMSAPI);
        Thread t = new Thread(Tref);
        t.Start(para);       

        return "";

    }

    public String SMSResetPassword(String phoneNumber, String Card_Code, String AccessCode)
    {
        String para;
        String content = "Mat khau cua ban da duoc thay doi." + "\\nMat khau moi: " + AccessCode + ".\\nVui long thay doi mat khau sau khi dang nhap.\\nTran trong";
        para = phoneNumber + "~" + content;
        ParameterizedThreadStart Tref = new ParameterizedThreadStart(SendSMSAPI);
        Thread t = new Thread(Tref);
        t.Start(para);

        return "";

    }


    public String SMSSendIncreaseTransaction(String phoneNumber, int ServiceAmount, int TotalPoint)
    {       

        int serviceAmountConvert = ServiceAmount/1000;
        int cost = TotalPoint * 50;

        String para;
        String content = "Diem so cua ban vua thay doi: +"+ serviceAmountConvert + " diem. \\nSo diem hien tai: " + TotalPoint + " diem tuong ung: " + cost + " VND.\\nTran trong";
        para = phoneNumber + "~" + content;
        ParameterizedThreadStart Tref = new ParameterizedThreadStart(SendSMSAPI);
        Thread t = new Thread(Tref);
        t.Start(para);

        return "";
    }
   

    public String SMSSendDescreaseTransaction(String phoneNumber, int ServiceAmount, int TotalPoint)
    {     

        int serviceAmountConvert = ServiceAmount/50;
        int cost = TotalPoint * 50;        

        String para;
        String content = "Diem so cua ban vua thay doi: -" + serviceAmountConvert + " diem. \\nSo diem hien tai: " + TotalPoint + " diem tuong ung: " + cost + " VND.\\nTran trong";
        para = phoneNumber + "~" + content;
        ParameterizedThreadStart Tref = new ParameterizedThreadStart(SendSMSAPI);
        Thread t = new Thread(Tref);
        t.Start(para);

        return "";

    }

    public void EmailSendAddMemberCard(String Email, String Card_Code, String AccessCode)
    {
        // Send Email đăng ký
        MailMessage mm = new MailMessage();
        mm.To.Add(Email);
        mm.From = new MailAddress("haiyeneyegroup@gmail.com", "Hai Yen Eye Care");
        mm.Subject = "Chúc mừng bạn đã đăng ký thành công chương trình thành viên";
        mm.Body = " Xin chào Quý bệnh nhân,<br/> Hai Yen Eye Care xin gửi thông tin đăng nhập của Quý bệnh nhân tại hệ thống chương trình thành viên của Trung tâm: <br/><br/> Mã thành viên: " + Card_Code + "<br/> Email đăng ký: " + Email + "<br/> Mật khẩu: " + AccessCode + "<br/> Đăng nhập ngay tại: http://member.haiyeneyecare.com" + "<br/><br/> Vui lòng đổi mật khẩu sau khi đăng nhập để đảm bảo tính bảo mật của thông tin " + "<br/><br/>Cảm ơn Quý bệnh nhân đã sử dụng dịch vụ tại hệ thống Trung tâm!" + "<br/>";
        mm.IsBodyHtml = true;

        // attach file trong mail
        string path = HttpContext.Current.Server.MapPath("~/Images/Gioi-thieu-chuong-trinh.pdf");
        Attachment data = new Attachment(path, MediaTypeNames.Application.Octet);
        mm.Attachments.Add(data);
       
        ParameterizedThreadStart Thread = new ParameterizedThreadStart(SendEmail);
        Thread th = new Thread(Thread);
        th.Start(mm);

    }

    public void EmailSendResetPassword(String Email, String Card_Code, String AccessCode)
    {
        // Send Email Reset Password

        MailMessage mm = new MailMessage();
        mm.To.Add(Email);
        mm.From = new MailAddress("haiyeneyegroup@gmail.com", "Hai Yen Eye Care");
        mm.Subject = "Cấp lại mật khẩu chương trình thành viên";
        mm.Body = " Xin chào Quý bệnh nhân,<br/> Hai Yen Eye Care xin gửi lại thông tin đăng nhập của Quý bệnh nhân tại hệ thống chương trình thành viên của Trung tâm: <br/><br/> Mã thành viên: " + Card_Code + "<br/> Mật khẩu mới: " + AccessCode + "<br/> Email đăng ký: " + Email + "<br/> Đăng nhập ngay tại: http://member.haiyeneyecare.com" + "<br/><br/>Vui lòng đổi mật khẩu sau khi đăng nhập để đảm bảo tính bảo mật của thông tin <br/><br/> Cảm ơn Quý bệnh nhân đã sử dụng dịch vụ tại hệ thống Trung tâm!" + "<br/>";
        mm.IsBodyHtml = true;


        ParameterizedThreadStart Thread = new ParameterizedThreadStart(SendEmail);
        Thread th = new Thread(Thread);
        th.Start(mm);

    }


    public void EmailSendTransaction(String Email, String Fullname, String Card_Code, String ServiceDate, String ServiceDescription, int ServiceAmount, int TotalPoint)
    {
        // Send Emai Transaction

        MailMessage mm = new MailMessage();
        mm.To.Add(Email);
        mm.From = new MailAddress("haiyeneyegroup@gmail.com", "Hai Yen Eye Care");
        mm.Subject = "Thông báo sử dụng giao dịch";
        mm.Body = " Xin chào " + Fullname + ", " + "<br/> Quý bệnh nhân vừa thực hiện giao dịch tại hệ thống chương trình thành viên của Trung tâm với: <br/><br/> Mã thành viên: " + Card_Code + "<br/> Ngày thực hiện giao dịch: " + ServiceDate + "<br/> Sử dụng dịch vụ: " + ServiceDescription + " với số tiền " + ServiceAmount + " VNĐ" + "<br/> Số điểm tích lũy hiện tại: " + TotalPoint + " điểm <br/><br/> Quý bệnh nhân kiểm tra thông tin giao dịch tại: http://member.haiyeneyecare.com" + "<br/><br/>Cảm ơn Quý bệnh nhân đã sử dụng dịch vụ tại hệ thống Trung tâm!" + "<br/>";
        mm.IsBodyHtml = true;

        ParameterizedThreadStart Thread = new ParameterizedThreadStart(SendEmail);
        Thread th = new Thread(Thread);
        th.Start(mm);

    }


    public void PostToWebAPI(string url, string token, NameValueCollection valueCollection)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            byte[] responseArray = wc.UploadValues(url, "POST", valueCollection);

            // Decode and display the response.
            //string temp = System.Text.Encoding.ASCII.GetString(responseArray);
        }
    }

    public bool SendNotifyCreatedByCardID(int card_ID, string accessCode = "")
    {
        DTO.tblCustomerMemberCardData member = BUS.tblCustomerMemberCardData.GetByID(card_ID);
        string url = System.Configuration.ConfigurationManager.AppSettings["Notifications_URL"] + "/api/membercards/sendNotifyCreated";
        string token = System.Configuration.ConfigurationManager.AppSettings["Notifications_Access_Token"];

        if (string.IsNullOrEmpty(accessCode))
        {
            // tao access code mới
            accessCode = Utilities.StringExts.RandomAccessCode();
            BUS.tblMemberCard.UpdatePassword(card_ID, accessCode);
        }

        NameValueCollection myNameValueCollection = new NameValueCollection();
        myNameValueCollection.Add("FullName", member.FullName);
        myNameValueCollection.Add("Email", member.Email);
        myNameValueCollection.Add("MobilePhone", member.MobilePhone);
        myNameValueCollection.Add("Card_Code", member.Card_Code);
        myNameValueCollection.Add("AccessCode", accessCode);

        try
        {
            PostToWebAPI(url, token, myNameValueCollection);
        }
        catch (Exception ex)
        {
            // pass to continue
        }
        
        return true;
    }

    public bool SendNotifyResetPasswordByCardID(int card_ID, string accessCode = "")
    {
        DTO.tblCustomerMemberCardData member = BUS.tblCustomerMemberCardData.GetByID(card_ID);
        string url = System.Configuration.ConfigurationManager.AppSettings["Notifications_URL"] + "/api/membercards/sendNotifyResetPassword";
        string token = System.Configuration.ConfigurationManager.AppSettings["Notifications_Access_Token"];

        if (!string.IsNullOrEmpty(accessCode))
        {
            NameValueCollection myNameValueCollection = new NameValueCollection();
            myNameValueCollection.Add("FullName", member.FullName);
            myNameValueCollection.Add("Email", member.Email);
            myNameValueCollection.Add("MobilePhone", member.MobilePhone);
            myNameValueCollection.Add("Card_Code", member.Card_Code);
            myNameValueCollection.Add("AccessCode", accessCode);

            try
            {
                PostToWebAPI(url, token, myNameValueCollection);
            }
            catch (Exception ex)
            {
                
                // pass to continue
            }            
            
            return true;
        }

        return false;
    }
}