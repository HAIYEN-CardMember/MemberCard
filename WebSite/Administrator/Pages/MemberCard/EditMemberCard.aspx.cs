using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mime;
public partial class Administrator_Pages_MemberCard_EditMemberCard : System.Web.UI.Page
{

    private void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDMember;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.Edit;
        Form.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            if (Request.QueryString["Card_ID"] == null)
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
            else
            {
                PageLoad();
            }
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
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

        txtCard_Code.Text = "";
        ddlCardType_ID.SelectedIndex = 0;
        ddlIssuePlace_ID.SelectedIndex = 0;
        ddlStatus_ID.SelectedIndex = 0;
        txtEMRCode.Text = "";
        ddlEMRPlace_ID.SelectedIndex = 0;
        ddlIssueDateYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlIssueDateMonth.SelectedValue = DateTime.Now.Month.ToString();
        ddlIssueDateDay.SelectedValue = DateTime.Now.Day.ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        /* Code cũ bị lỗi update tạo thêm 1 MemberCard mới
         * 
        if (IsValid)
        {
            int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());            

            DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);
            if (memberCard != null && memberCard.Card_ID > 0)
            {
                DTO.tblCustomer customer = BUS.tblCustomer.GetByID(memberCard.Customer_ID);

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

                //memberCard.Card_ID = txtCard_ID.Text != "" ? Convert.ToInt32(txtCard_ID.Text) : 0;
                memberCard.Card_ID = Card_ID;
                memberCard.Customer_ID = customer.Customer_ID;
                memberCard.CardType_ID = Convert.ToInt32(ddlCardType_ID.SelectedItem.Value);
                memberCard.IssuePlace_ID = Convert.ToInt32(ddlIssuePlace_ID.SelectedItem.Value);
                memberCard.IssueDate = new DateTime(Convert.ToInt32(ddlIssueDateYear.SelectedItem.Value), Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value), Convert.ToInt32(ddlIssueDateDay.SelectedItem.Value));
                memberCard.IssueBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffName;
                memberCard.ExpDate = memberCard.IssueDate.AddYears(1);
                memberCard.Status_ID = Convert.ToInt32(ddlStatus_ID.SelectedItem.Value);
                memberCard.EMRCode = txtEMRCode.Text;
                memberCard.EMRPlace_ID = Convert.ToInt32(ddlEMRPlace_ID.SelectedItem.Value);
                memberCard.AccessCode = memberCard.AccessCode;
                memberCard.TotalPoint = txtTotalPoint.Text != "" ? Convert.ToInt32(txtTotalPoint.Text.Replace(",", "")) : 0; ;
                memberCard.Notes = txtNote.Text;
                memberCard.Card_Code = txtCard_Code.Text;

                lbSuccess.Text = "";
                lbError.Text = "";
                DTO.tblCustomer c = null;
                if (customer.Email != null && customer.Email != "")
                    c = BUS.tblCustomer.GetByEmail(customer.Customer_ID, customer.Email);
                if (c == null || c.Customer_ID == 0)
                {
                    if (BUS.tblMemberCard.Update(memberCard) > 0 && BUS.tblCustomer.Create(customer) > 0)                    
                    {
                        lbSuccess.Text = "Cập nhật thành công";
                    }
                    else
                    {
                        lbError.Text = "Cập nhật thất bại";
                    }
                }
                else
                {
                    lbError.Text = "Email đã tồn tại";
                    lbSuccess.Text = "";
                }
            }
        }
        */

        int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());


        DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);
        if (memberCard != null && memberCard.Card_ID > 0)
        {
            DTO.tblCustomer customer = BUS.tblCustomer.GetByID(memberCard.Customer_ID);

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
                        
            
           int Customer_ID = customer.Customer_ID;           
           int CardType_ID = Convert.ToInt32(ddlCardType_ID.SelectedItem.Value);         
           int IssuPlace_ID = Convert.ToInt32(ddlIssuePlace_ID.SelectedItem.Value);

           DateTime IssueDate = new DateTime(Convert.ToInt32(ddlIssueDateYear.SelectedItem.Value), Convert.ToInt32(ddlIssueDateMonth.SelectedItem.Value), Convert.ToInt32(ddlIssueDateDay.SelectedItem.Value));
           DateTime ExpDate = Convert.ToDateTime(memberCard.ExpDate);
   
           string IssueBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffName;                         
           int Status_ID = Convert.ToInt32(ddlStatus_ID.SelectedItem.Value);
           string EMRCode = txtEMRCode.Text;          
           int EMRPlace_ID = Convert.ToInt32(ddlEMRPlace_ID.SelectedItem.Value);
           string AccessCode = memberCard.AccessCode;
           //int TotalPoint = txtTotalPoint.Text != "" ? Convert.ToInt32(txtTotalPoint.Text.Replace(",", ",")) : 0; ;           
           int TotalPoint = Convert.ToInt32(memberCard.TotalPoint.ToString());
           string Notes = txtNote.Text;
           string Card_Code = txtCard_Code.Text;

            lbSuccess.Text = "";
            lbError.Text = "";

            DTO.tblCustomer c = null;

            if (customer.Email != null && customer.Email != "")
                c = BUS.tblCustomer.GetByEmail(customer.Customer_ID, customer.Email);
            if (c == null || c.Customer_ID == 0)
            {
                if (BUS.tblCustomer.Create(customer) > 0)
                {
                    String UpdateBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffID;
                    BUS.tblMemberCard.Update(Card_ID, CardType_ID, Customer_ID, IssueDate, IssuPlace_ID, IssueBy, ExpDate, Status_ID, TotalPoint, AccessCode, EMRCode, EMRPlace_ID, Notes, Card_Code, UpdateBy);
                    lbSuccess.Text = "Cập nhật thành công";
                }
                else
                {
                    lbError.Text = "Cập nhật thất bại";
                }
            }
            else
            {
                lbError.Text = "Email đã tồn tại";
                lbSuccess.Text = "";
            }

        }

    }

    private void PageLoadLine()
    {
        int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
        lkSwichCard.NavigateUrl = String.Format(Page.ResolveUrl("/admin/chuyen-ma-the/{0}.html"), Card_ID);
        DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);

        if (memberCard != null && memberCard.Card_ID > 0)
        {
            txtCard_ID.Text = memberCard.Card_ID.ToString();
            ddlCardType_ID.Text = memberCard.CardType_ID.ToString();
            txtCard_Code.Text = memberCard.Card_Code;
            ddlIssueDateDay.SelectedValue = memberCard.IssueDate.Day.ToString();
            ddlIssueDateMonth.SelectedValue = memberCard.IssueDate.Month.ToString();
            ddlIssueDateYear.SelectedValue = memberCard.IssueDate.Year.ToString();
            ddlIssuePlace_ID.SelectedValue = memberCard.IssuePlace_ID.ToString();
            lbIssueBy.Text = memberCard.IssueBy;
            ddlStatus_ID.SelectedValue = memberCard.Status_ID.ToString();
            txtEMRCode.Text = memberCard.EMRCode;
            ddlEMRPlace_ID.SelectedValue = memberCard.EMRPlace_ID.ToString();
            txtTotalPoint.Text = memberCard.TotalPoint.Value.ToString("N0");
            txtNote.Text = memberCard.Notes.ToString();

            DTO.tblCustomer customer = BUS.tblCustomer.GetByID(memberCard.Customer_ID);
            txtFullName.Text = customer.FullName;
            ddlGender_ID.SelectedValue = customer.Gender_ID.ToString();
            if (customer.DOB != null)
            {                
                ddlDay.SelectedValue = customer.DOB.Value.Day.ToString();
                ddlMonth.SelectedValue = customer.DOB.Value.Month.ToString();
                ddlYear.SelectedValue = customer.DOB.Value.Year.ToString();
            }
            else
            {
                ddlDay.SelectedValue = "";
                ddlMonth.SelectedValue = "";
                ddlYear.SelectedValue = "";
            }
           
            txtAddressLine1.Text = customer.AddressLine1;
            txtAddressLine2.Text = customer.AddressLine2;
            txtMobilePhone.Text = customer.MobilePhone;
            txtPhone2.Text = customer.Phone2;
            txtEmail.Text = customer.Email;
        }
        else
            Response.Redirect("/admin/the-thanh-vien/index.html");
    }

    private void PageLoad()
    {
        lbTitle.Text = "CHỈNH SỬA THÔNG TIN KHÁCH HÀNG";
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
        PageLoadLine();
    }

    protected void lbReset_Click(object sender, EventArgs e)
    {
        int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
        string accessCode = Utilities.StringExts.RandomAccessCode();
        BUS.tblMemberCard.UpdatePassword(Card_ID, accessCode);

        DTO.tblCustomerMemberCard item = BUS.tblCustomerMemberCard.GetByID(Card_ID);
        int customer_id = item.Customer_ID;
        DTO.tblCustomer customer = BUS.tblCustomer.GetByID(customer_id);

        Common cm = new Common();

        if (customer.Email != null && customer.Email != "")
        {
            try
            {
                cm.EmailSendResetPassword(customer.Email, txtCard_Code.Text, accessCode);
                lbSuccess.Text = "Đã cấp lại qua e-mail với mật khẩu mới: " + accessCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            lbSuccess.Text = "Email không tồn tại. Kiểm tra lại Email!";
        }

        if (customer.MobilePhone != null)
        {
            try
            {
                cm.SMSResetPassword(customer.MobilePhone, txtCard_Code.Text, accessCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            lbSuccess.Text = "Số điện thoại không tồn tại!";
        }       

        //Common common = new Common();
        //common.SendNotifyResetPasswordByCardID(Card_ID, accessCode);        
        //Response.Redirect(String.Format("/admin/the-thanh-vien/cap-nhat-thanh-cong/{0}/{1}.html", Card_ID, accessCode));
    }
}