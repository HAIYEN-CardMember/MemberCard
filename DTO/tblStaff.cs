using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tblStaff
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string AccessCode { get; set; }
        public int Place_ID { get; set; }
        public int AdminRight { get; set; }
        public int UPDMember { get; set; }
        public int UPDServiceTransaction { get; set; }
        public int UPDPaymentTransaction { get; set; }
        public int UPDPointRule { get; set; }
        public int UPDChangeCard { get; set; }
        public int RPTMember { get; set; }
        public int RPTServiceTransaction { get; set; }
        public int RPTPaymentTransaction { get; set; }
        public int RPTReportIncrease_Decrease { get; set; }
        public int RPTReportServiceAmount { get; set; }

        public tblStaff()
        {
            StaffID = "";
            StaffName = "";
            AccessCode = "";
            Place_ID = 0;
            AdminRight = 0;
            UPDMember = 0;
            UPDServiceTransaction = 0;
            UPDPaymentTransaction = 0;
            UPDPointRule = 0;
            UPDChangeCard = 0;
            RPTMember = 0;
            RPTServiceTransaction = 0;
            RPTPaymentTransaction = 0;
            RPTReportIncrease_Decrease = 0;
            RPTReportServiceAmount = 0;
        }

        public tblStaff(System.Data.DataRow row)
        {
            StaffID = row["StaffID"].ToString();
            StaffName = row["StaffName"].ToString();
            AccessCode = row["AccessCode"].ToString();
            Place_ID = row["Place_ID"].ToString() != "" ? Convert.ToInt32(row["Place_ID"]) : 0;
            AdminRight = row["AdminRight"].ToString() != "" ? Convert.ToInt32(row["AdminRight"]) : 0;
            UPDMember = row["UPDMember"].ToString() != "" ? Convert.ToInt32(row["UPDMember"]) : 0;
            UPDServiceTransaction = row["UPDServiceTransaction"].ToString() != "" ? Convert.ToInt32(row["UPDServiceTransaction"]) : 0;
            UPDPaymentTransaction = row["UPDPaymentTransaction"].ToString() != "" ? Convert.ToInt32(row["UPDPaymentTransaction"]) : 0;
            UPDPointRule = row["UPDPointRule"].ToString() != "" ? Convert.ToInt32(row["UPDPointRule"]) : 0;
            UPDChangeCard = row["UPDChangeCard"].ToString() != "" ? Convert.ToInt32(row["UPDChangeCard"]) : 0;
            RPTMember = row["RPTMember"].ToString() != "" ? Convert.ToInt32(row["RPTMember"]) : 0;
            RPTServiceTransaction = row["RPTServiceTransaction"].ToString() != "" ? Convert.ToInt32(row["RPTServiceTransaction"]) : 0;
            RPTPaymentTransaction = row["RPTPaymentTransaction"].ToString() != "" ? Convert.ToInt32(row["RPTPaymentTransaction"]) : 0;
            RPTReportIncrease_Decrease = row["RPTReportIncrease_Decrease"].ToString() != "" ? Convert.ToInt32(row["RPTReportIncrease_Decrease"]) : 0;
            RPTReportServiceAmount = row["RPTReportServiceAmount"].ToString() != "" ? Convert.ToInt32(row["RPTReportServiceAmount"]) : 0;

            UPDMember = AdminRight > 0 ? 15 : UPDMember;
            UPDServiceTransaction = AdminRight > 0 ? 15 : UPDServiceTransaction;
            UPDPaymentTransaction = AdminRight > 0 ? 15 : UPDPaymentTransaction;
            UPDPointRule = AdminRight > 0 ? 15 : UPDPointRule;
            UPDChangeCard = AdminRight > 0 ? 15 : UPDChangeCard;
            RPTMember = AdminRight > 0 ? 15 : RPTMember;
            RPTServiceTransaction = AdminRight > 0 ? 15 : RPTServiceTransaction;
            RPTPaymentTransaction = AdminRight > 0 ? 15 : RPTPaymentTransaction;
            RPTReportIncrease_Decrease = AdminRight > 0 ? 15 : RPTReportIncrease_Decrease;
            RPTReportServiceAmount = AdminRight > 0 ? 15 : RPTReportServiceAmount;
        }
    }
}
