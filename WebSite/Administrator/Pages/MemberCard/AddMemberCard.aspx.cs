using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mime;

public partial class Administrator_Pages_MemberCard_AddMemberCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageLoad();
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDMember;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.Add;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFullName.Text = "";
        ddlGender_ID.SelectedIndex = 0;
        txtMobilePhone.Text = "";
        txtPhone2.Text = "";
        txtAddressLine1.Text = "";
        txtAddressLine2.Text = "";
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        ddlDay.SelectedIndex = 0;

        txtCard_ID.Text = "";
        ddlCardType_ID.SelectedIndex = 0;
        ddlIssuePlace_ID.SelectedIndex = 0;
        ddlStatus_ID.SelectedIndex = 0;
        txtEMRCode.Text = "";
        ddlEMRPlace_ID.SelectedIndex = 0;
        ddlIssueDateYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlIssueDateMonth.SelectedValue = DateTime.Now.Month.ToString();
        ddlIssueDateDay.SelectedValue = DateTime.Now.Day.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            DTO.tblCustomer customer = new DTO.tblCustomer();
            customer.FullName = txtFullName.Text;
            customer.Gender_ID = Convert.ToInt32(ddlGender_ID.SelectedItem.Value);
            customer.MobilePhone = txtMobilePhone.Text;
            customer.Phone2 = txtPhone2.Text;
            customer.Email = txtEmail.Text;
            customer.AddressLine1 = txtAddressLine1.Text;
            customer.AddressLine2 = txtAddressLine2.Text;
            if (ddlYear.SelectedItem.Value != "")
            {
                customer.YOB = Convert.ToInt32(ddlYear.SelectedItem.Value);
                if (ddlMonth.SelectedItem.Value != "" && ddlDay.SelectedItem.Value != "")
                {
                    customer.DOB = new DateTime(Convert.ToInt32(ddlYear.SelectedItem.Value), Convert.ToInt32(ddlMonth.SelectedItem.Value), 1);
                    int day = customer.DOB.Value.AddMonths(1).AddDays(-1).Day <= Convert.ToInt32(ddlDay.SelectedItem.Value) ? customer.DOB.Value.AddMonths(1).AddDays(-1).Day : Convert.ToInt32(ddlDay.SelectedItem.Value);
                    customer.DOB = customer.DOB.Value.AddDays(day - 1);
                }
            }

            DTO.tblMemberCard memberCard = new DTO.tblMemberCard();
            memberCard.Card_ID = txtCard_ID.Text != "" ? Convert.ToInt32(txtCard_ID.Text) : 0;
            memberCard.Card_Code = txtCard_Code.Text.Trim();
            memberCard.CardType_ID = Convert.ToInt32(ddlCardType_ID.SelectedItem.Value);
            memberCard.IssuePlace_ID = Convert.ToInt32(ddlIssuePlace_ID.SelectedItem.Value);
            // memberCard.IssueDate = new DateTime(Convert.ToInt32(ddlIssueDateYear.SelectedItem.Value), Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value), Convert.ToInt32(ddlIssueDateDay.SelectedItem.Value));

            // Xử lý ngày cấp thẻ tháng 10, 11, 12 thì ngày hết hạn sử dụng thẻ là: 31/12 năm tiếp theo, các tháng còn lại mặc định là 31/12 năm cũ
            //String dateString = "12/31/2017";
           // String dateString_nextyear = "12/31/2018";
            memberCard.IssueDate = new DateTime(Convert.ToInt32(ddlIssueDateYear.SelectedItem.Value), Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value), Convert.ToInt32(ddlIssueDateDay.SelectedItem.Value));

            //if (Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value) == 10 || Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value) == 11 || Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value) == 12)
            //{
            //    //memberCard.ExpDate = memberCard.IssueDate.AddYears(1);
            //    memberCard.ExpDate = DateTime.Parse(dateString_nextyear);
            //}

            //else
            //{
            //    memberCard.ExpDate = DateTime.Parse(dateString);
            //}

            // memberCard.ExpDate = memberCard.IssueDate.AddYears(1);
            memberCard.SetExpDate();
            memberCard.IssueBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffName;
            memberCard.CreateBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffID;
            memberCard.Status_ID = Convert.ToInt32(ddlStatus_ID.SelectedItem.Value);
            memberCard.EMRCode = txtEMRCode.Text.Trim();
            memberCard.EMRPlace_ID = Convert.ToInt32(ddlEMRPlace_ID.SelectedItem.Value);
            memberCard.AccessCode = Utilities.StringExts.RandomAccessCode();
            memberCard.TotalPoint = txtTotalPoint.Text.Trim() != "" ? Convert.ToInt32(txtTotalPoint.Text.Replace(",", "")) : 0;
            memberCard.Notes = txtNote.Text;
            
            lbSuccess.Text = "";
            lbError.Text = "";
            // neu card_code rong th insert nguoc lai kiem tra ton tai
            if (string.IsNullOrEmpty(memberCard.Card_Code) || BUS.tblMemberCard.GetByCardCode(memberCard.Card_Code) == null)
            {
                DTO.tblCustomer c = null;
                if (customer.Email != null && customer.Email != "")
                    c = BUS.tblCustomer.GetByEmail(0, customer.Email);
                if (c == null || c.Customer_ID == 0)
                {
                    if (BUS.tblCustomer.Create(customer) > -1)
                    {
                        memberCard.Customer_ID = customer.Customer_ID;
                        memberCard.Card_ID = BUS.tblMemberCard.Create(memberCard);
                        if (memberCard.Card_ID > 0)
                        {                                                                                   

                            Response.Redirect(String.Format("/admin/the-thanh-vien/them-thanh-cong/{0}/{1}.html", memberCard.Card_ID, memberCard.AccessCode));
                        }
                        else
                        {
                            lbError.Text = "Thêm thông tin khách hàng không thành công";
                            BUS.tblCustomer.Delete(memberCard.Customer_ID);
                        }
                    }
                    else
                    {
                        lbError.Text = "Thêm thông tin khách hàng không thành công";
                    }
                }
                else
                {
                    lbError.Text = "Email đã tồn tại";
                    lbSuccess.Text = "";
                }
            }
            else
            {
                lbError.Text = "Mã thẻ đã tồn tại";
            }

        }
    }



    private void PageLoad()
    {
        lbTitle.Text = "MỞ THẺ MỚI";
        ddlGender_ID.DataSource = BUS.tblGender.GetAll();
        ddlGender_ID.DataValueField = "Gender_ID";
        ddlGender_ID.DataTextField = "Description";
        if (ddlGender_ID.Items.Count > 0)
            ddlGender_ID.SelectedIndex = 0;
        ddlGender_ID.DataBind();

        ddlCardType_ID.DataSource = BUS.tblCardType.GetAll();
        ddlCardType_ID.DataValueField = "CardType_ID";
        ddlCardType_ID.DataTextField = "Description";
        if (ddlCardType_ID.Items.Count > 0)
            ddlCardType_ID.SelectedIndex = 0;
        ddlCardType_ID.DataBind();

        ddlEMRPlace_ID.DataSource = BUS.tblServicePlace.GetAll();
        ddlEMRPlace_ID.DataValueField = "Place_ID";
        ddlEMRPlace_ID.DataTextField = "PlaceName";
        if (ddlEMRPlace_ID.Items.Count > 0)
            ddlEMRPlace_ID.SelectedIndex = 0;
        ddlEMRPlace_ID.DataBind();

        ddlIssuePlace_ID.DataSource = BUS.tblServicePlace.GetAll();
        ddlIssuePlace_ID.DataValueField = "Place_ID";
        ddlIssuePlace_ID.DataTextField = "PlaceName";
        if (ddlIssuePlace_ID.Items.Count > 0)
            ddlIssuePlace_ID.SelectedIndex = 0;
        ddlIssuePlace_ID.DataBind();

        ddlStatus_ID.DataSource = BUS.tblStatus.GetAll();
        ddlStatus_ID.DataValueField = "Status_ID";
        ddlStatus_ID.DataTextField = "Description";
        if (ddlStatus_ID.Items.Count > 0)
            ddlStatus_ID.SelectedIndex = 0;
        ddlStatus_ID.DataBind();

        ddlDay.Items.Add(new ListItem("[Chọn]", ""));
        for (int i = 1; i <= 31; i++)
        {
            ddlDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlIssueDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        if (ddlDay.Items.Count > 0)
            ddlDay.SelectedIndex = 0;
        ddlDay.DataBind();

        ddlIssueDateDay.SelectedValue = DateTime.Now.Day.ToString();

        ddlMonth.Items.Add(new ListItem("[Chọn]", ""));
        for (int i = 1; i <= 12; i++)
        {
            ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlIssueDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        if (ddlMonth.Items.Count > 0)
            ddlMonth.SelectedIndex = 0;
        ddlMonth.DataBind();

        ddlIssueDateMonth.SelectedValue = DateTime.Now.Month.ToString();

        ddlYear.Items.Add(new ListItem("[Chọn]", ""));
        for (int i = DateTime.Now.Year; i >= 1900; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlIssueDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        if (ddlYear.Items.Count > 0)
            ddlYear.SelectedIndex = 0;
        ddlYear.DataBind();

        ddlIssueDateYear.SelectedValue = DateTime.Now.Year.ToString();
        lbIssueBy.Text = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffName;

    }
}
