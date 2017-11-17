using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_EditStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["StaffID"] == null)
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
            else
            {
                PageLoad();
                PageLoadLine();
            }
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

    private void PageLoadLine()
    {
        string Staff_ID = Request.QueryString["StaffID"].ToString();
        DTO.tblStaff staff = BUS.tblStaff.GetByID(Staff_ID);
        if (staff != null)
        {
            txtStaffID.Text = staff.StaffID.ToString();
            txtStaffName.Text = staff.StaffName.ToString();

        }
        else
            Response.Redirect("/admin/the-thanh-vien/index.html");
    }

    protected void lbReset_Click(object sender, EventArgs e)
    {
        string Staff_ID = Request.QueryString["StaffID"].ToString();
        string accessCode = Utilities.StringExts.RandomAccessCode();
        BUS.tblStaff.UpdatePassword(Staff_ID, accessCode);
        lbSuccess.Text = "Mật khẩu mới của nhân viên là: " + accessCode;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        String Staff_ID = Request.QueryString["StaffID"].ToString();
        String StaffName = txtStaffName.Text;
        DTO.tblStaff staff = BUS.tblStaff.GetByID(Staff_ID);
        if (staff != null)
        {
            staff.StaffName = txtStaffName.Text;
            staff.Place_ID = Convert.ToInt32(ddlPlace_ID.SelectedItem.Value);
            BUS.tblStaff.Create(staff);
            lbSuccess.Text = "Cập nhật thông tin thành công";
        }
        else
        {
            lbError.Text = "Cập nhật thất bại";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        String Staff_ID = Request.QueryString["StaffID"].ToString();

        DTO.tblStaff staff = BUS.tblStaff.GetByID(Staff_ID);
        if (staff != null)
        {

            BUS.tblStaff.Delete(Staff_ID);

            Response.Redirect("/admin/the-thanh-vien/quan-ly-nhan-vien.html");
        }
        else
        {
            lbError.Text = "Lỗi xóa nhân viên";
        }
    }

}