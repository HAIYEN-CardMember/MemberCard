using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_EditPointRule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDPointRule;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.Edit;
        if (!IsPostBack)
        {
            if (Request.QueryString["Rule_ID"] == null)
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
            else
            {
                PageLoadLine();
            }
        }
    }


    private void PageLoadLine()
    {
        int RuleID = Convert.ToInt32(Request.QueryString["Rule_ID"].ToString());

        DTO.tblPointRule rule = BUS.tblPointRule.GetByID(RuleID);

        if (rule != null)
        {
            txtRuleID.Text = rule.Rule_ID.ToString();
            txtDescription.Text = rule.Description.ToString();
            txtChangeRate.Text = rule.ChangeRate.ToString();
            txtIncrease.Text = rule.Increase_Decrease.ToString();

        }
        else
            Response.Redirect("/admin/the-thanh-vien/index.html");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int RuleID = Convert.ToInt32(Request.QueryString["Rule_ID"].ToString());
        String Description = txtDescription.Text;
        int ChangeRate = Convert.ToInt32(txtChangeRate.Text);
        int increase_decrease = Convert.ToInt32(txtIncrease.Text);


        DTO.tblPointRule rule = BUS.tblPointRule.GetByID(RuleID);
        if (rule != null)
        {

            BUS.tblPointRule.Update(RuleID, Description, ChangeRate, increase_decrease);
            lbSuccess.Text = "cập nhật Rule thành công";
        }
        else
        {
            lbError.Text = "cập nhật thất bại";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int RuleID = Convert.ToInt32(Request.QueryString["Rule_ID"].ToString());

        DTO.tblPointRule rule = BUS.tblPointRule.GetByID(RuleID);
        if (rule != null)
        {

            BUS.tblPointRule.Delete(RuleID);

            Response.Redirect("/admin/the-thanh-vien/quan-ly-rule.html");
        }
        else
        {
            lbError.Text = "Lỗi xóa rule";
        }
    }
}