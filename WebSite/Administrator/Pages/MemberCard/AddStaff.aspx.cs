using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_AddStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageLoad();
        }
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.AdminRight;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
    }
    private void PageLoad()
    {
        List<DTO.tblServicePlace> lsServicePlace = BUS.tblServicePlace.GetAll();
        lsServicePlace.Insert(0, new DTO.tblServicePlace() { Place_ID = 0, PlaceName = "Tất cả" });
        ddlPlace_ID.DataSource = lsServicePlace;
        ddlPlace_ID.DataValueField = "Place_ID";
        ddlPlace_ID.DataTextField = "PlaceName";
        if (ddlPlace_ID.Items.Count > 0)
            ddlPlace_ID.SelectedIndex = 0;
        ddlPlace_ID.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            DTO.tblStaff item = new DTO.tblStaff();
            item.StaffID = txtStaffID.Text.Trim();
            item.StaffName = txtStaffName.Text;
            item.AccessCode = txtAccessCode.Text;
            item.Place_ID = Convert.ToInt32(ddlPlace_ID.SelectedItem.Value);

            if (BUS.tblStaff.GetByID(item.StaffID) == null)
            {

                BUS.tblStaff.Create(item);
                lbSuccess.Text = "Bạn đã thêm nhân viên: " + item.StaffName + " - với mật khẩu:  " + item.AccessCode;
            }
            else
            {
                lbError.Text = "Nhân viên đã tồn tại";
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtStaffID.Text = "";
        txtStaffName.Text = "";
        txtAccessCode.Text = "";
    }
}