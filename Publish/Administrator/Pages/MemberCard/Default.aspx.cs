using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


public partial class Administrator_Pages_MemberCard_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadData();
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDMember;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        string cardCode = txtMaThe.Text.Trim();
        gvData.DataSource = BUS.tblCustomerMemberCard.GetBySearch(txtTenKhachHang.Text.Trim(), 0, cardCode, txtMaHoSo.Text.Trim());

        //gvData.Columns[6].ItemStyle.BackColor = System.Drawing.Color.Gray;

        gvData.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMaHoSo.Text = "";
        txtMaThe.Text = "";
        txtTenKhachHang.Text = "";
        LoadData();
    }
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[8].Text == "Locked")
                e.Row.BackColor = Color.FromArgb(255, 160, 160);
        }
    }
}