using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tblCustomerMemberCard
    {
        public int No_ { get; set; }
        public int Card_ID { get; set; }
        public string Card_Code { get; set; }
        public int Customer_ID { get; set; }
        public string FullName { get; set; }
        public string FullNameSearch { get; set; }
        public string EMRCode { get; set; }
        public string MobilePhone { get; set; }
        public System.DateTime IssueDate { get; set; }
        public System.DateTime? ExpDate { get; set; }
        public int Place_ID { get; set; }
        public string PlaceName { get; set; }
        public string Color { get; set; }
        public string IssueBy { get; set; }
        public int? TotalPoint { get; set; }
        public string Description { get; set; }

        public tblCustomerMemberCard()
        {
            No_ = 0;
            Card_ID = 0;
            Card_Code = "";
            Customer_ID = 0;
            FullName = "";
            FullNameSearch = null;
            EMRCode = null;
            MobilePhone = null;
            IssueBy = null;
            IssueDate = DateTime.Now;
            ExpDate = (DateTime?)null;
            Place_ID = 0;
            PlaceName = "";
            Color = "";
            TotalPoint = (int?)null;
            Description = "";
        }

        public tblCustomerMemberCard(System.Data.DataRow row)
        {
            No_ = row["No_"].ToString() != "" ? Convert.ToInt32(row["No_"]) : 0;
            Card_ID = row["Card_ID"].ToString() != "" ? Convert.ToInt32(row["Card_ID"]) : 0;
            Card_Code = row["Card_Code"].ToString();
            Customer_ID = row["Customer_ID"].ToString() != "" ? Convert.ToInt32(row["Customer_ID"]) : 0;
            FullName = row["FullName"].ToString();
            FullNameSearch = row["FullNameSearch"].ToString();
            EMRCode = row["EMRCode"].ToString();
            MobilePhone = row["MobilePhone"].ToString();
            IssueBy = row["IssueBy"].ToString();
            IssueDate = row["IssueDate"].ToString() != "" ? Convert.ToDateTime(row["IssueDate"]) : DateTime.Now;
            ExpDate = row["ExpDate"].ToString() != "" ? Convert.ToDateTime(row["ExpDate"]) : (DateTime?)null;
            Place_ID = row["Place_ID"].ToString() != "" ? Convert.ToInt32(row["Place_ID"]) : 0;
            PlaceName = row["PlaceName"].ToString();
            Color = row["Color"].ToString();
            TotalPoint = row["TotalPoint"].ToString() != "" ? Convert.ToInt32(row["TotalPoint"]) : (int?)null;
            Description = row["Description"].ToString();
        }
    }
}
