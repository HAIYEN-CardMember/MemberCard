using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
public partial class Pages_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string txtAccessCodeNew = Utilities.StringExts.RandomAccessCode();

        if (IsValid)
        {
            DTO.tblCustomerMemberCardData cardData = BUS.tblCustomerMemberCardData.GetByCustomerEmail(txtUserName.Text.Trim()).FirstOrDefault();

            if (BUS.tblMemberCard.ResetPassword(cardData.Email, txtAccessCodeNew))
            {
                Common common = new Common();
                common.SendNotifyResetPasswordByCardID(cardData.Card_ID, txtAccessCodeNew);

                lbSuccess.Text = "Đã tạo mới mật khẩu thành công qua email!";
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