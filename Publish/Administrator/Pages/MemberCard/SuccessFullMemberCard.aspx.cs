using System;
using System.Collections.Generic;
using System.Linq;
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
                lbFullName.Text = item.FullName;
                lbAccessCode.Text = AccessCode;
                lbCard_ID.Text = item.Card_ID.ToString();
                lbCard_Code.Text = item.Card_Code;
                lbExpDate.Text = item.ExpDate == null ? "Không hết hạn" : item.ExpDate.Value.ToString("dd/MM/yyyy");
                lbTotalPoint.Text = item.TotalPoint == null ? "Không có điểm" : item.TotalPoint.Value.ToString("N0");
            }
            else
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
        }
    }
}