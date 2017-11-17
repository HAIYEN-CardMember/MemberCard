using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_StaffConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadData();
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.AdminRight;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/the-thanh-vien/them-nhan-vien.html");
    }

    private void LoadData()
    {
        List<DTO.tblStaff> lsArray = BUS.tblStaff.GetAll();

        gvData.DataSource = lsArray;
        gvData.DataBind();
    }


    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        LoadData();
    }
}