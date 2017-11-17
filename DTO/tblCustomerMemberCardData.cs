using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tblCustomerMemberCardData
    {
        public int Card_ID { get; set; }
        public string Card_Code { get; set; }
        public int CardType_ID { get; set; }
        public int Customer_ID { get; set; }
        public System.DateTime IssueDate { get; set; }
        public int? IssuePlace_ID { get; set; }
        public string IssueBy { get; set; }
        public System.DateTime? ExpDate { get; set; }
        public int? Status_ID { get; set; }
        public int? TotalPoint { get; set; }
        public string AccessCode { get; set; }
        public string EMRCode { get; set; }
        public int? EMRPlace_ID { get; set; }
        public string Notes { get; set; }
        public string FullName { get; set; }
        public string FullNameSearch { get; set; }
        public int Gender_ID { get; set; }
        public System.DateTime? DOB { get; set; }
        public int? YOB { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string MobilePhone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }

        public tblCustomerMemberCardData()
        {
            Card_ID = 0;
            Card_Code = "";
            CardType_ID = 0;
            Customer_ID = 0;
            IssueDate = DateTime.Now;
            IssuePlace_ID = 0;
            IssueBy = "";
            ExpDate = DateTime.Now;
            Status_ID = 0;
            TotalPoint = 0;
            AccessCode = "";
            EMRCode = "";
            EMRPlace_ID = 0;
            Notes = "";
            FullName = "";
            FullNameSearch = null;
            Gender_ID = 0;
            DOB = (DateTime?)null;
            YOB = (int?)null;
            AddressLine1 = null;
            AddressLine2 = null;
            MobilePhone = null;
            Phone2 = null;
            Email = null;
        }

        public tblCustomerMemberCardData(System.Data.DataRow row)
        {
            Card_ID = row["Card_ID"].ToString() != "" ? Convert.ToInt32(row["Card_ID"]) : 0;
            Card_Code = row["Card_Code"].ToString();
            CardType_ID = row["CardType_ID"].ToString() != "" ? Convert.ToInt32(row["CardType_ID"]) : 0;
            Customer_ID = row["Customer_ID"].ToString() != "" ? Convert.ToInt32(row["Customer_ID"]) : 0;
            IssueDate = row["IssueDate"].ToString() != "" ? Convert.ToDateTime(row["IssueDate"]) : DateTime.Now;
            IssuePlace_ID = row["IssuePlace_ID"].ToString() != "" ? Convert.ToInt32(row["IssuePlace_ID"]) : 0;
            IssueBy = row["IssueBy"].ToString();
            ExpDate = row["ExpDate"].ToString() != "" ? Convert.ToDateTime(row["ExpDate"]) : DateTime.Now;
            Status_ID = row["Status_ID"].ToString() != "" ? Convert.ToInt32(row["Status_ID"]) : 0;
            TotalPoint = row["TotalPoint"].ToString() != "" ? Convert.ToInt32(row["TotalPoint"]) : 0;
            AccessCode = row["AccessCode"].ToString();
            EMRCode = row["EMRCode"].ToString();
            EMRPlace_ID = row["EMRPlace_ID"].ToString() != "" ? Convert.ToInt32(row["EMRPlace_ID"]) : 0;
            Notes = row["Notes"].ToString();
            FullName = row["FullName"].ToString();
            Gender_ID = row["Gender_ID"].ToString() != "" ? Convert.ToInt32(row["Gender_ID"]) : 0;
            DOB = row["DOB"].ToString() != "" ? Convert.ToDateTime(row["DOB"]) : (DateTime?)null;
            YOB = row["YOB"].ToString() != "" ? Convert.ToInt32(row["YOB"]) : (int?)null;
            AddressLine1 = row["AddressLine1"].ToString();
            AddressLine2 = row["AddressLine2"].ToString();
            MobilePhone = row["MobilePhone"].ToString();
            Phone2 = row["Phone2"].ToString();
            Email = row["Email"].ToString();
        }

        public DTO.tblCustomer GetCustomer()
        {
            DTO.tblCustomer result = new DTO.tblCustomer
            {
                Customer_ID = this.Customer_ID,
                FullName = this.FullName,
                FullNameSearch = this.FullNameSearch,
                Gender_ID = this.Gender_ID,
                DOB = this.DOB,
                YOB = this.YOB,
                AddressLine1 = this.AddressLine1,
                AddressLine2 = this.AddressLine2,
                MobilePhone = this.MobilePhone,
                Phone2 = this.Phone2,
                Email = this.Email
            };
            return result;
        }
    }
}
