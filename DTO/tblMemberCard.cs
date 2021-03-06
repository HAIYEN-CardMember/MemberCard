﻿using System;

namespace DTO
{
    public class tblMemberCard
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

        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime? CreateDate { get; set; }
        public System.DateTime? UpdateDate { get; set; }

        public tblMemberCard()
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
            CreateBy = "";
            UpdateBy = "";
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;

        }

        public void SetExpDate()
        {
            if (IssueDate != null)
            {
                if (IssueDate.Month > 9)
                {
                    ExpDate = new DateTime(IssueDate.Year + 1, 12, 31);
                }
                else
                {
                    ExpDate = new DateTime(IssueDate.Year, 12, 31);
                }
            }

        }
        public tblMemberCard(System.Data.DataRow row)
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
            CreateBy = row["CreateBy"].ToString();
            UpdateBy = row["UpdateBy"].ToString();
            CreateDate = row["CreateDate"].ToString() != "" ? Convert.ToDateTime(row["CreateDate"]) : DateTime.Now;
            UpdateDate = row["UpdateDate"].ToString() != "" ? Convert.ToDateTime(row["UpdateDate"]) : DateTime.Now;
        }
    }
}