using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

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