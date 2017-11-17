using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mime;

public partial class Pages_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        DTO.tblMemberCard memberCard = new DTO.tblMemberCard();
        memberCard.AccessCode = Utilities.StringExts.RandomAccessCode();
        string txtAccessCodeNew = memberCard.AccessCode;
        Common cm = new Common();

        if (IsValid)
        {
                DTO.tblCustomerMemberCardData cardData = BUS.tblCustomerMemberCardData.GetByCustomerEmail(txtUserName.Text.Trim()).FirstOrDefault();

                if (BUS.tblMemberCard.ResetPassword(txtUserName.Text, txtAccessCodeNew))
                {

                            try
                            {
                                cm.EmailSendResetPassword(txtUserName.Text, cardData.Card_Code, txtAccessCodeNew);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }             

                            lbSuccess.Text = "Đã cấp lại mật khẩu mới qua email!";
                            lbError.Text = "";                
                }
                else
                {
                    lbError.Text = "Không tồn tại Email";
                    lbSuccess.Text = "";
                }
        }
    }
}