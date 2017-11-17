using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_RuleConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDPointRule;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
        if (!IsPostBack)
            LoadData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/the-thanh-vien/them-rule.html");
    }

    private void LoadData()
    {
        List<DTO.tblPointRule> lsArray = BUS.tblPointRule.GetAll();

        gvData.DataSource = lsArray;
        gvData.DataBind();
    }


    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        LoadData();
    }
}