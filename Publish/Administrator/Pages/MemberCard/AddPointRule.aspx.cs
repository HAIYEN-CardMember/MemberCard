using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_AddPointRule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDPointRule;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.Add;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtRuleID.Text = "";
        txtDescription.Text = "";
        txtChangeRate.Text = "";
        txtIncrease.Text = "";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int Rule_ID = Convert.ToInt16(txtRuleID.Text);
            String Description = txtDescription.Text;
            int ChangeRate = Convert.ToInt32(txtChangeRate.Text);
            int Increase_Des = Convert.ToInt32(txtIncrease.Text);

            if (BUS.tblPointRule.GetByID(Rule_ID) == null)
            {

                BUS.tblPointRule.Create(Rule_ID, Description, ChangeRate, Increase_Des);
                lbSuccess.Text = "Bạn đã thêm được rule: " + Description;
            }
            else
            {
                lbError.Text = "Rule đã tồn tại";
            }
        }
    }
}