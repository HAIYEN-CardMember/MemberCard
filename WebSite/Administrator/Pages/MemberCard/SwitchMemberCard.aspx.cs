using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_SwitchMemberCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDChangeCard;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.Edit;
        if (!IsPostBack)
        {
            if (Request.QueryString["Card_ID"] == null)
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
            else
            {
                txtFrom_Card_ID.Text = Request.QueryString["Card_ID"].ToString();

            }
        }
    }
    protected void btnSwitch_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {

            int From_Card_ID = Convert.ToInt32(txtFrom_Card_ID.Text.Trim());
            int To_Card_ID = Convert.ToInt32(txtTo_Card_ID.Text.Trim());
            if (BUS.tblMemberCard.GetByID(From_Card_ID) == null)
            {
                lbError.Text = "Mã thẻ cũ không tồn tại";
            }
            else if (BUS.tblMemberCard.GetByID(To_Card_ID) != null)
            {
                lbError.Text = "Mã thẻ mới không tồn tại";
            }
            else
            {
                int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
                string issueBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffName;
                if (BUS.tblMemberCard.Switch(From_Card_ID, To_Card_ID, issueBy))
                {
                    DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);
                    if (memberCard.Status_ID == 0)
                    {
                        BUS.tblMemberCard.MemberCard_UpdateStatus(Card_ID);
                    }

                    lbError.Text = "Chuyển mã thẻ thành công";
                    Response.Redirect("/admin/the-thanh-vien/index.html");

                }
                else
                {
                    lbError.Text = "Chuyển mã thẻ thất bại";
                }
            }
        }
    }
}