using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net.Mail;
using System.Net.Mime;

public class AuthHeader : SoapHeader
{
    public string Password;
    public string Username;

    public AuthHeader()
    {
        Username = "";
        Password = "";
    }
}

/// <summary>
/// Summary description for MemberCardService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
// [System.Web.Script.Services.ScriptService]
public class MemberCardService : System.Web.Services.WebService
{
    public MemberCardService()
    {        //Uncomment the following line if using designed components
        //InitializeComponent();
        AuthenticationInfo = new AuthHeader();
    }

    public AuthHeader AuthenticationInfo { get; set; }

    #region MemberCardAndCustomer

    /// <summary>
    /// Thêm khách hàng có mã thẻ
    /// </summary>
    /// <param name="Card_Code">Mã thẻ</param>
    /// <param name="CardType_ID">Loại thẻ</param>
    /// <param name="IssueDate">Ngày phát hành</param>
    /// <param name="IssuePlace_ID">Nơi phát hành</param>
    /// <param name="IssueBy">Nhân viên phát hành</param>
    /// <param name="ExpDate">Ngày hết hạn</param>
    /// <param name="Status_ID">Trạng thái</param>
    /// <param name="TotalPoint">Tổng điểm</param>
    /// <param name="AccessCode">Mật khẩu</param>
    /// <param name="EMRCode">Mã bệnh án</param>
    /// <param name="EMRPlace_ID">Nơi lập</param>
    /// <param name="Notes">Ghi chú</param>
    /// <param name="FullName">Họ và tên</param>
    /// <param name="Gender_ID">Giới tính</param>
    /// <param name="DOB">Ngày thánh năm sinh</param>
    /// <param name="YOB">Năm sinh</param>
    /// <param name="AddressLine1">Địa chỉ</param>
    /// <param name="AddressLine2">Quận</param>
    /// <param name="MobilePhone">Điện thoại</param>
    /// <param name="Phone2">Điện thoại khác</param>
    /// <param name="Email">Email</param>
    /// <returns>Mã thành viên</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thêm khách hàng có mã thẻ")]
    public int AddMemberCardAndCustomer(string Card_Code, int CardType_ID, DateTime IssueDate, int IssuePlace_ID, string IssueBy, DateTime ExpDate, int Status_ID, int TotalPoint, string AccessCode, string EMRCode, int EMRPlace_ID, string Notes, string FullName, int Gender_ID, DateTime DOB, int YOB, string AddressLine1, string AddressLine2, string MobilePhone, string Phone2, string Email, string CreateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblCustomer customer = new DTO.tblCustomer();
        customer.FullName = FullName;
        customer.FullNameSearch = Utilities.StringExts.ToAscii(customer.FullName);
        customer.Gender_ID = Gender_ID;
        customer.DOB = DOB;
        customer.YOB = YOB;
        customer.AddressLine1 = AddressLine1;
        customer.AddressLine2 = AddressLine2;
        customer.MobilePhone = MobilePhone;
        customer.Phone2 = Phone2;
        customer.Email = Email;

        DTO.tblMemberCard memberCard = new DTO.tblMemberCard();
        //memberCard.Card_ID = Card_ID;
        memberCard.Card_Code = Card_Code;
        memberCard.CardType_ID = CardType_ID;
        memberCard.IssueDate = IssueDate;
        memberCard.IssuePlace_ID = IssuePlace_ID;
        //memberCard.IssueBy = IssueBy;
        memberCard.IssueBy = CreateBy;
        memberCard.ExpDate = ExpDate;
        memberCard.SetExpDate();
        memberCard.Status_ID = Status_ID;
        memberCard.TotalPoint = TotalPoint;
        AccessCode = Utilities.StringExts.RandomAccessCode();
        memberCard.AccessCode = AccessCode;
        memberCard.EMRCode = EMRCode;
        memberCard.EMRPlace_ID = EMRPlace_ID;
        memberCard.Notes = Notes;
        memberCard.CreateBy = CreateBy;

        // neu card_code rong th insert nguoc lai kiem tra ton tai
        if (string.IsNullOrEmpty(memberCard.Card_Code) || BUS.tblMemberCard.GetByCardCode(memberCard.Card_Code) == null)
        {
            if (BUS.tblCustomer.Create(customer) > -1)
            {
                memberCard.Customer_ID = customer.Customer_ID;
                memberCard.Card_ID = BUS.tblMemberCard.Create(memberCard);
                memberCard.Card_Code = BUS.tblMemberCard.GetByID(memberCard.Card_ID).Card_Code;
                if (memberCard.Card_ID > 0)
                {
                    Common cm = new Common();
                    if (customer.Email != null && customer.Email != "")
                    {
                        try
                        {
                            cm.EmailSendAddMemberCard(customer.Email, memberCard.Card_Code, AccessCode);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    if (customer.MobilePhone != null)
                    {
                        try
                        {
                            cm.SMSSendOpenCard(customer.MobilePhone, memberCard.Card_Code, AccessCode);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    return memberCard.Card_ID;
                }
                else
                {
                    BUS.tblCustomer.Delete(memberCard.Customer_ID);
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Gửi thông báo tạo thành viên thành công
    /// </summary>
    /// <param name="card_ID">Mã thẻ</param>
    /// /// <param name="AccessCode">Mã đăng nhập</param>
    /// <returns>TRUE|FALSE</returns>
    //[SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Gửi thông báo tạo thành viên thành công")]
    public bool SendNotifyCreated(int card_ID)
    {
        //if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
        //    throw new System.Security.Authentication.AuthenticationException();

        Common common = new Common();
        return common.SendNotifyCreatedByCardID(card_ID);
    }

    /// <summary>
    /// Xóa thông tin thẻ thành viên, xóa Customer, xóa service transaction
    /// </summary>
    /// <param name="card_ID">Mã thẻ</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Xóa thông tin thẻ thành viên, xóa Customer, xóa service transaction")]
    public bool DeleteMemberCardAndCustomer(int card_ID, string UpdateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(card_ID);
        if (memberCard.Card_ID > 0)
        {
            BUS.tblCustomer.Delete(memberCard.Customer_ID);
            BUS.tblServiceTransaction.DeleteByCard_ID(memberCard.Card_ID, UpdateBy);
            return BUS.tblCustomer.Delete(memberCard.Customer_ID) > -1;
        }
        return false;
    }

    /// <summary>
    /// Danh sách khách hàng có mã thẻ
    /// </summary>
    /// <returns>List đối tượng tblCustomerMemberCard</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách khách hàng có mã thẻ")]
    public List<DTO.tblCustomerMemberCard> GetMemberCardAndCustomer()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCard.GetAll();
    }

    /// <summary>
    /// Khách hàng có mã thẻ theo ID
    /// </summary>
    /// <param name="card_id">Mã thẻ</param>
    /// <returns>Đối tượng tblCustomerMemberCard</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Khách hàng có mã thẻ theo ID")]
    public DTO.tblCustomerMemberCard GetMemberCardAndCustomerByID(int card_id)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCard.GetByID(card_id);
    }

    /// <summary>
    /// Cập nhật khách hàng có mã thẻ
    /// </summary>
    /// <param name="Card_ID">Mã thẻ</param>
    /// <param name="CardType_ID">Loại thẻ</param>
    /// <param name="IssueDate">Ngày phát hành</param>
    /// <param name="IssuePlace_ID">Nơi phát hành</param>
    /// <param name="IssueBy">Nhân viên phát hành</param>
    /// <param name="ExpDate">Ngày hết hạn</param>
    /// <param name="Status_ID">Trạng thái</param>
    /// <param name="TotalPoint">Tổng điểm</param>
    /// <param name="AccessCode">Mật khẩu</param>
    /// <param name="EMRCode">Mã bệnh án</param>
    /// <param name="EMRPlace_ID">Nơi lập</param>
    /// <param name="Notes">Ghi chú</param>
    /// <param name="FullName">Họ và tên</param>
    /// <param name="Gender_ID">Giới tính</param>
    /// <param name="DOB">Ngày thánh năm sinh</param>
    /// <param name="YOB">Năm sinh</param>
    /// <param name="AddressLine1">Địa chỉ</param>
    /// <param name="AddressLine2">Quận</param>
    /// <param name="MobilePhone">Điện thoại</param>
    /// <param name="Phone2">Điện thoại khác</param>
    /// <param name="Email">Email</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Cập nhật khách hàng có mã thẻ")]
    public bool UpdateMemberCardAndCustomer(int Card_ID, int CardType_ID, DateTime IssueDate, int IssuePlace_ID, string IssueBy, DateTime ExpDate, int Status_ID, int TotalPoint, string AccessCode, string EMRCode, int EMRPlace_ID, string Notes, string FullName, int Gender_ID, DateTime DOB, int YOB, string AddressLine1, string AddressLine2, string MobilePhone, string Phone2, string Email, string UpdateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);
        if (memberCard != null && memberCard.Card_ID > 0)
        {
            DTO.tblCustomer customer = BUS.tblCustomer.GetByID(memberCard.Customer_ID);

            memberCard.Card_ID = Card_ID;
            memberCard.CardType_ID = CardType_ID;
            memberCard.IssueDate = IssueDate;
            memberCard.IssuePlace_ID = IssuePlace_ID;
            memberCard.IssueBy = IssueBy;
            memberCard.ExpDate = ExpDate;
            memberCard.Status_ID = Status_ID;
            memberCard.TotalPoint = TotalPoint;
            memberCard.AccessCode = AccessCode;
            memberCard.EMRCode = EMRCode;
            memberCard.EMRPlace_ID = EMRPlace_ID;
            memberCard.Notes = Notes;
            memberCard.UpdateBy = UpdateBy;

            customer.FullName = FullName;
            customer.FullNameSearch = Utilities.StringExts.ToAscii(customer.FullName);
            customer.Gender_ID = Gender_ID;
            customer.DOB = DOB;
            customer.YOB = YOB;
            customer.AddressLine1 = AddressLine1;
            customer.AddressLine2 = AddressLine2;
            customer.MobilePhone = MobilePhone;
            customer.Phone2 = Phone2;
            customer.Email = Email;

            if (BUS.tblMemberCard.Create(memberCard) > 0 && BUS.tblCustomer.Create(customer) > 0)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    #endregion MemberCardAndCustomer

    #region tblGender

    /// <summary>
    /// Danh sách giới tính
    /// </summary>
    /// <returns>List đối tượng tblGender</returns>
    [WebMethod(Description = "Danh sách giới tính")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public List<DTO.tblGender> GetGender()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblGender.GetAll();
    }

    #endregion tblGender

    #region tblServiceTransaction

    /// <summary>
    /// Thêm thông tin giao dịch sử dụng dịch vụ của khách hàng
    /// </summary>
    /// <param name="Card_ID">Mã thẻ</param>
    /// <param name="ServiceDate">Ngày sử dụng dịch vụ</param>
    /// <param name="ServicePlace_ID">Nơi sử dụng dịch vụ</param>
    /// <param name="ServiceDescription">Dịch vụ khách sử dụng:</param>
    /// <param name="ServiceAmount">Số giao dịch:</param>
    /// <param name="Increase_Decrease">Loại giao dịch:</param>
    /// <param name="AutoTransferInput"></param>
    /// <param name="PointRule_ID">Cách tính điểm</param>
    /// <param name="PointRec">Số điểm tích lũy:</param>
    /// <returns>TRUE|FALSE</returns>
    [WebMethod(Description = "Thêm thông tin giao dịch sử dụng dịch vụ của khách hàng")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public int AddServiceTransaction(int Card_ID, DateTime ServiceDate, int ServicePlace_ID, string ServiceDescription, int ServiceAmount, int Increase_Decrease, bool AutoTransferInput, int PointRule_ID, int PointRec, string CreateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblServiceTransaction item = new DTO.tblServiceTransaction();
        item.Card_ID = Card_ID;
        item.ServiceDate = ServiceDate;
        item.ServicePlace_ID = ServicePlace_ID;
        item.ServiceDescription = ServiceDescription;
        item.ServiceAmount = ServiceAmount;
        item.Increase_Decrease = Increase_Decrease;
        item.AutoTransferInput = AutoTransferInput;
        item.PointRule_ID = PointRule_ID;
        item.PointRec = PointRec;
        item.CreateBy = CreateBy;
        int result = 0;
        if (BUS.tblServiceTransaction.Create(item) > 0) 
        {
            DTO.tblCustomerMemberCardData tblCustomerMemberCardData = BUS.tblCustomerMemberCardData.GetByID(Card_ID);
            result = tblCustomerMemberCardData.TotalPoint ?? 0;
            Common cm = new Common();

            if (tblCustomerMemberCardData.MobilePhone != null)
            {
                if (Increase_Decrease == -1)
                {
                   try
                    {
                        cm.SMSSendDescreaseTransaction(tblCustomerMemberCardData.MobilePhone, item.ServiceAmount, Convert.ToInt16(tblCustomerMemberCardData.TotalPoint));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
                if (Increase_Decrease == 1)
                {
                    try
                    {
                        cm.SMSSendIncreaseTransaction(tblCustomerMemberCardData.MobilePhone, item.ServiceAmount, Convert.ToInt16(tblCustomerMemberCardData.TotalPoint));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            if (tblCustomerMemberCardData.Email != null && tblCustomerMemberCardData.Email != "")
            {
                try
                {
                    cm.EmailSendTransaction(tblCustomerMemberCardData.Email, tblCustomerMemberCardData.FullName, tblCustomerMemberCardData.Card_Code, Convert.ToString(item.ServiceDate.ToString("dd/MM/yyyy")), item.ServiceDescription, item.ServiceAmount, Convert.ToInt16(tblCustomerMemberCardData.TotalPoint));
                }
                catch (Exception ex)
                { }
            }            
        }
        else
        {
            result = -1;
        }
        return result;
    }

    /// <summary>
    /// Xóa thông tin giao dịch sử dụng dịch vụ của khách hàng theo Member Card ID
    /// </summary>
    /// <param name="ID">Mã thẻ</param>
    /// <returns>TRUE|FALSE</returns>
    [WebMethod(Description = "Xóa thông tin giao dịch sử dụng dịch vụ của khách hàng theo Member Card ID")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public bool DeleteServiceTransactionByCardID(int ID, string UpdateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServiceTransaction.DeleteByCard_ID(ID, UpdateBy) > 0;
    }

    /// <summary>
    /// Xóa thông tin giao dịch sử dụng dịch vụ của khách hàng theo ID
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns>TRUE|FALSE</returns>
    [WebMethod(Description = "Xóa thông tin giao dịch sử dụng dịch vụ của khách hàng theo ID")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public bool DeleteServiceTransactionByID(int ID, string UpdateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServiceTransaction.Delete(ID, UpdateBy) > 0;
    }

    /// <summary>
    /// Danh sách thông tin giao dịch sử dụng dịch vụ của khách hàng
    /// </summary>
    /// <returns>List đối tượng tblServiceTransaction</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin giao dịch sử dụng dịch vụ của khách hàng")]
    public List<DTO.tblServiceTransaction> GetServiceTransaction()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServiceTransaction.GetAll();
    }

    /// <summary>
    /// Danh sách thông tin giao dịch sử dụng dịch vụ của khách hàng theo Member Card ID
    /// </summary>
    /// <param name="CardID">Mã thẻ</param>
    /// <returns>List đối tượng tblServiceTransaction</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin giao dịch sử dụng dịch vụ của khách hàng theo Member Card ID")]
    public List<DTO.tblServiceTransaction> GetServiceTransactionByCardID(int CardID)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServiceTransaction.GetByCard_ID(CardID);
    }

    /// <summary>
    /// Thông tin giao dịch sử dụng dịch vụ của khách hàng theo ID
    /// </summary>
    /// <param name="ID">ID</param>
    /// <returns>Đối tượng tblServiceTransaction</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thông tin giao dịch sử dụng dịch vụ của khách hàng theo ID")]
    public DTO.tblServiceTransaction GetServiceTransactionGetByID(int ID)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServiceTransaction.GetByID(ID);
    }

    #endregion tblServiceTransaction

    #region tblServicePlace

    /// <summary>
    /// Danh sách nơi cung cấp dịch vụ
    /// </summary>
    /// <returns>List đối tượng tblServicePlace</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách nơi cung cấp dịch vụ")]
    public List<DTO.tblServicePlace> GetServicePlace()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblServicePlace.GetAll();
    }

    #endregion tblServicePlace

    #region tblCardType

    /// <summary>
    /// Danh sách loại thẻ thành viên
    /// </summary>
    /// <returns>List đối tượng tblCardType</returns>
    [WebMethod(Description = "Danh sách loại thẻ thành viên")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public List<DTO.tblCardType> GetCardType()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCardType.GetAll();
    }

    #endregion tblCardType

    #region tblStatus

    /// <summary>
    /// Danh sách tình trạng thẻ
    /// </summary>
    /// <returns>List đối tượng tblStatus</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách tình trạng thẻ")]
    public List<DTO.tblStatus> GetStatus()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblStatus.GetAll();
    }

    #endregion tblStatus

    #region tblPointRule

    /// <summary>
    /// Danh sách các luật tính điểm
    /// </summary>
    /// <returns>List đối tượng tblPointRule</returns>
    [WebMethod(Description = "Danh sách các luật tính điểm")]
    [SoapHeader("AuthenticationInfo", Required = true)]
    public List<DTO.tblPointRule> GetPointRule()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblPointRule.GetAll();
    }

    #endregion tblPointRule

    #region tblCustomer

    /// <summary>
    /// Thêm thông tin khách hàng
    /// </summary>
    /// <param name="fullName">Tên khách hàng</param>
    /// <param name="gender_ID">Giới tinh khách hàng</param>
    /// <param name="DOB">Ngày tháng năm sinh</param>
    /// <param name="YOB">Năm sinh</param>
    /// <param name="AddressLine1">Địa chỉ</param>
    /// <param name="AddressLine2">Quận</param>
    /// <param name="MobilePhone">Điện thoại</param>
    /// <param name="Phone2">Điện thoại khác</param>
    /// <param name="Email">Email</param>
    /// <returns>Trả về số tự tăng Customer_ID</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thêm thông tin khách hàng")]
    public int AddCustomer(string fullName, int gender_ID, DateTime? DOB, int? YOB, string addressLine1, string addressLine2, string mobilePhone, string phone2, string email)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblCustomer item = new DTO.tblCustomer();
        item.Customer_ID = 0;
        item.FullName = fullName;
        item.Gender_ID = gender_ID;
        item.DOB = DOB;
        item.YOB = YOB;
        item.AddressLine1 = addressLine1;
        item.AddressLine2 = addressLine2;
        item.MobilePhone = null;
        item.Phone2 = phone2;
        item.Email = email;
        return BUS.tblCustomer.Create(item);
    }

    /// <summary>
    /// Xóa thông tin khách hàng
    /// </summary>
    /// <param name="customer_ID">Xóa thông tin khách hàng theo mã khách hàng</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Xóa thông tin khách hàng")]
    public bool DeleteCustomer(int customer_ID)
    {
        return BUS.tblCustomer.Delete(customer_ID) > 0;
    }

    /// <summary>
    /// Danh sách thông tin khách hàng
    /// </summary>
    /// <returns>List đối tượng tblCustomer</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin khách hàng")]
    public List<DTO.tblCustomer> GetCustomer()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomer.GetAll();
    }

    /// <summary>
    /// Thông tin khách hàng theo ID
    /// </summary>
    /// <param name="customer_id">Mã khách hàng</param>
    /// <returns>Đối tượng tblCustomer</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thông tin khách hàng theo ID")]
    public DTO.tblCustomer GetCustomerByID(int customer_id)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomer.GetByID(customer_id);
    }

    /// <summary>
    /// Cập nhật thông tin khách hàng
    /// </summary>
    /// <param name="customer_ID">Cập nhật thông tin theo mã khách hàng</param>
    /// <param name="fullName">Tên khách hàng</param>
    /// <param name="gender_ID">Giới tinh khách hàng</param>
    /// <param name="DOB">Ngày tháng năm sinh</param>
    /// <param name="YOB">Năm sinh</param>
    /// <param name="AddressLine1">Địa chỉ</param>
    /// <param name="AddressLine2">Quận</param>
    /// <param name="MobilePhone">Điện thoại</param>
    /// <param name="Phone2">Điện thoại khác</param>
    /// <param name="Email">Email</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Cập nhật thông tin khách hàng")]
    public bool UpdateCustomer(int customer_ID, string fullName, int gender_ID, DateTime? DOB, int? YOB, string addressLine1, string addressLine2, string mobilePhone, string phone2, string email)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblCustomer item = new DTO.tblCustomer();
        item.Customer_ID = customer_ID;
        item.FullName = fullName;
        item.Gender_ID = gender_ID;
        item.DOB = DOB;
        item.YOB = YOB;
        item.AddressLine1 = addressLine1;
        item.AddressLine2 = addressLine2;
        item.MobilePhone = null;
        item.Phone2 = phone2;
        item.Email = email;
        return BUS.tblCustomer.Create(item) > 0;
    }

    #endregion tblCustomer

    #region tblMemberCard

    /// <summary>
    /// Cập nhật thông tin thẻ
    /// </summary>
    /// <param name="Card_ID">Mã thẻ</param>
    /// <param name="CardType_ID">Loại thẻ</param>
    /// <param name="customer_ID"></param>
    /// <param name="IssueDate">Ngày phát hành</param>
    /// <param name="IssuePlace_ID">Nơi phát hành</param>
    /// <param name="IssueBy">Nhân viên phát hành</param>
    /// <param name="ExpDate">Ngày hết hạn</param>
    /// <param name="Status_ID">Trạng thái</param>
    /// <param name="TotalPoint">Tổng điểm</param>
    /// <param name="AccessCode">Mật khẩu</param>
    /// <param name="EMRCode">Mã bệnh án</param>
    /// <param name="EMRPlace_ID">Nơi lập</param>
    /// <param name="Notes">Ghi chú</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thêm thông tin thẻ")]
    public bool AddMemberCard(int card_ID, int cardType_ID, int customer_ID, DateTime issueDate, int issuePlace_ID, string issueBy, DateTime expDate, int status_ID, int totalPoint, string accessCode, string eMRCode, int eMRPlace_ID, string notes)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblMemberCard item = BUS.tblMemberCard.GetByID(card_ID);
        if (item == null && item.Card_ID == 0)
        {
            item.Card_ID = card_ID;
            item.CardType_ID = cardType_ID;
            item.Customer_ID = customer_ID;
            item.IssueDate = issueDate;
            item.IssuePlace_ID = issuePlace_ID;
            item.IssueBy = issueBy;
            item.ExpDate = expDate;
            item.Status_ID = status_ID;
            item.TotalPoint = totalPoint;
            item.AccessCode = accessCode;
            item.EMRCode = eMRCode;
            item.EMRPlace_ID = eMRPlace_ID;
            item.Notes = notes;
            return BUS.tblMemberCard.Create(item) > 0;
        }
        else
            return false;
    }

    /// <summary>
    /// Xóa thông tin thẻ, không xóa thông tin khách hàng
    /// </summary>
    /// <param name="card_id">Xóa thông tin thẻ theo mã thẻ</param>
    /// <returns></returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Xóa thông tin thẻ, không xóa thông tin khách hàng")]
    public bool DeleteMemberCard(int card_id)
    {
        return BUS.tblMemberCard.Delete(card_id) > 0;
    }

    /// <summary>
    /// Danh sách thông tin thẻ
    /// </summary>
    /// <returns>List đối tượng tblMemberCard</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ")]
    public List<DTO.tblMemberCard> GetMemberCard()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblMemberCard.GetAll();
    }

    /// <summary>
    /// Danh sách thông tin thẻ theo mã khách hàng
    /// </summary>
    /// <param name="customer_ID">Mã khách hàng</param>
    /// <returns>List đối tượng tblMemberCard</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ theo mã khách hàng")]
    public List<DTO.tblMemberCard> GetMemberCardByCustomerID(int customer_ID)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblMemberCard.GetByCustomerID(customer_ID);
    }

    /// <summary>
    /// Thông tin thẻ theo ID
    /// </summary>
    /// <param name="card_id">Mã thẻ</param>
    /// <returns>Đối tượng tblMemberCard</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thông tin thẻ theo ID")]
    public DTO.tblMemberCard GetMemberCardByID(int card_id)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblMemberCard.GetByID(card_id);
    }

    /// <summary>
    /// Cập nhật thông tin thẻ
    /// </summary>
    /// <param name="Card_ID">Mã thẻ</param>
    /// <param name="CardType_ID">Loại thẻ</param>
    /// <param name="customer_ID"></param>
    /// <param name="IssueDate">Ngày phát hành</param>
    /// <param name="IssuePlace_ID">Nơi phát hành</param>
    /// <param name="IssueBy">Nhân viên phát hành</param>
    /// <param name="ExpDate">Ngày hết hạn</param>
    /// <param name="Status_ID">Trạng thái</param>
    /// <param name="TotalPoint">Tổng điểm</param>
    /// <param name="AccessCode">Mật khẩu</param>
    /// <param name="EMRCode">Mã bệnh án</param>
    /// <param name="EMRPlace_ID">Nơi lập</param>
    /// <param name="Notes">Ghi chú</param>
    /// <returns>TRUE|FALSE</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Cập nhật thông tin thẻ")]
    public bool UpdateMemberCard(int card_ID, int cardType_ID, int customer_ID, DateTime issueDate, int issuePlace_ID, string issueBy, DateTime expDate, int status_ID, int totalPoint, string accessCode, string eMRCode, int eMRPlace_ID, string notes, string UpdateBy)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        DTO.tblMemberCard item = new DTO.tblMemberCard();
        item.Card_ID = card_ID;
        item.CardType_ID = cardType_ID;
        item.Customer_ID = customer_ID;
        item.IssueDate = issueDate;
        item.IssuePlace_ID = issuePlace_ID;
        item.IssueBy = issueBy;
        item.ExpDate = expDate;
        item.Status_ID = status_ID;
        item.TotalPoint = totalPoint;
        item.AccessCode = accessCode;
        item.EMRCode = eMRCode;
        item.EMRPlace_ID = eMRPlace_ID;
        item.Notes = notes;
        item.UpdateBy = UpdateBy;
        return BUS.tblMemberCard.Create(item) > 0;
    }

    #endregion tblMemberCard

    #region tblCustomerMemberCardData

    /// <summary>
    /// Danh sách thông tin thẻ và khách hàng (Data)
    /// </summary>
    /// <returns>List đối tượng tblCustomerMemberCardData</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ và khách hàng (Data)")]
    public List<DTO.tblCustomerMemberCardData> GetCustomerMemberCardData()
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCardData.GetAll();
    }

    /// <summary>
    /// Danh sách thông tin thẻ và khách hàng theo mã khách hàng (Data)
    /// </summary>
    /// <param name="customer_ID">Mã khách hàng</param>
    /// <returns>List đối tượng tblCustomerMemberCardData</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ và khách hàng theo mã khách hàng (Data)")]
    public List<DTO.tblCustomerMemberCardData> GetCustomerMemberCardDataByCustomerID(int customer_ID)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCardData.GetByCustomerID(customer_ID);
    }

    /// <summary>
    /// Danh sách thông tin thẻ và khách hàng theo số điện thoại (Data)
    /// </summary>
    /// <param name="customer_MobilePhone">Số điện thoại</param>
    /// <returns>List đối tượng tblCustomerMemberCardData</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ và khách hàng theo số điện thoại (Data)")]
    public List<DTO.tblCustomerMemberCardData> GetCustomerMemberCardDataByPhone(string customer_MobilePhone)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCardData.GetByCustomerPhone(customer_MobilePhone);
    }

    /// <summary>
    /// Danh sách thông tin thẻ và khách hàng theo mã thẻ (Data)
    /// </summary>
    /// <param name="card_Code">Mã thẻ</param>
    /// <returns>List đối tượng tblCustomerMemberCardData</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Danh sách thông tin thẻ và khách hàng theo mã thẻ (Data)")]
    public List<DTO.tblCustomerMemberCardData> GetCustomerMemberCardDataByCardCode(string card_Code)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCardData.GetByCardCode(card_Code);
    }

    /// <summary>
    /// Thông tin thẻ và khách hàng theo ID (Data)
    /// </summary>
    /// <param name="card_id">Mã thẻ</param>
    /// <returns>Đối tượng tblCustomerMemberCardData</returns>
    [SoapHeader("AuthenticationInfo", Required = true)]
    [WebMethod(Description = "Thông tin thẻ và khách hàng theo ID (Data)")]
    public DTO.tblCustomerMemberCardData GetCustomerMemberCardDataByID(int card_id)
    {
        if (!(AuthenticationInfo.Username == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoUsername"] && AuthenticationInfo.Password == System.Configuration.ConfigurationManager.AppSettings["AuthenticationInfoPassword"]))
            throw new System.Security.Authentication.AuthenticationException();
        return BUS.tblCustomerMemberCardData.GetByID(card_id);
    }

    #endregion tblCustomerMemberCardData
}