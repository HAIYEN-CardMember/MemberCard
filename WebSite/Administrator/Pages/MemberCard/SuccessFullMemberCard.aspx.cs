using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_SuccessFullMemberCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
            if (Request.QueryString["Card_ID"] != null && Request.QueryString["AccessCode"] != null)
            {
                int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
                string AccessCode = Request.QueryString["AccessCode"].ToString();

                DTO.tblCustomerMemberCard item = BUS.tblCustomerMemberCard.GetByID(Card_ID);
                int customer_id = item.Customer_ID;
                DTO.tblCustomer customer = BUS.tblCustomer.GetByID(customer_id);

                lbFullName.Text = item.FullName;
                lbAccessCode.Text = AccessCode;
                lbCard_ID.Text = item.Card_ID.ToString();
                lbCard_Code.Text = item.Card_Code;
                lbExpDate.Text = item.ExpDate == null ? "Không hết hạn" : item.ExpDate.Value.ToString("dd/MM/yyyy");
                lbTotalPoint.Text = item.TotalPoint == null ? "Không có điểm" : item.TotalPoint.Value.ToString("N0");
                Common cm = new Common();

                if (customer.Email != null && customer.Email != "")
                {
                    try
                    {
                        cm.EmailSendAddMemberCard(customer.Email, lbCard_Code.Text, lbAccessCode.Text);                       
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                if (customer.MobilePhone != null)
                {                   
                   cm.SMSSendOpenCard(customer.MobilePhone, lbCard_Code.Text, AccessCode);
                }                         
            }
            else
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
        }
    }
}