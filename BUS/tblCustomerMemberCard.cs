using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblCustomerMemberCard
    {

        public static List<DTO.tblCustomerMemberCard> GetAll()
        {
            return DAO.tblCustomerMemberCard.Get("", 0, "", "", null, null, 0);
        }

        public static List<DTO.tblCustomerMemberCard> GetBySearch(string FullNameSearch, int Card_ID, string EMRCode)
        {
            FullNameSearch = Utilities.StringExts.ToAscii(FullNameSearch);
            return DAO.tblCustomerMemberCard.Get(FullNameSearch, Card_ID, "", EMRCode, null, null, 0);
        }

        public static List<DTO.tblCustomerMemberCard> GetBySearch(string FullNameSearch, int Card_ID, string Card_Code, string EMRCode)
        {
            FullNameSearch = Utilities.StringExts.ToAscii(FullNameSearch);
            return DAO.tblCustomerMemberCard.Get(FullNameSearch, Card_ID, Card_Code, EMRCode, null, null, 0);
        }

        public static List<DTO.tblCustomerMemberCard> GetSearchPhone(string FullNameSearch, int Card_ID, string Card_Code, string EMRCode, string MobilePhone)
        {
            FullNameSearch = Utilities.StringExts.ToAscii(FullNameSearch);
            return DAO.tblCustomerMemberCard.GetSearchPhone(FullNameSearch, Card_ID, Card_Code, EMRCode, MobilePhone, null, null, 0);
        }

        public static List<DTO.tblCustomerMemberCard> GetByIssueDate(DateTime DateBegin, DateTime DateEnd, int Place_ID)
        {
            return DAO.tblCustomerMemberCard.Get("", 0, "", "", DateBegin, DateEnd, Place_ID);
        }

        public static DTO.tblCustomerMemberCard GetByID(int Card_ID)
        {
            return DAO.tblCustomerMemberCard.Get("", Card_ID, "", "", null, null, 0).FirstOrDefault();
        }

        public static DTO.tblCustomerMemberCard GetByCardCode(string CardCode)
        {
            return DAO.tblCustomerMemberCard.Get("", 0, CardCode, "", null, null, 0).FirstOrDefault();
        }

        public static int Create(DTO.tblCustomerMemberCard item)
        {
            return DAO.tblCustomerMemberCard.Create(item);
        }

        public static int Delete()
        {
            return DAO.tblCustomerMemberCard.Delete();
        }
        public static System.Data.DataTable GetDataByIssueDate(DateTime DateBegin, DateTime DateEnd, int Place_ID)
        {
            return DAO.tblCustomerMemberCard.GetData("", 0, "", DateBegin, DateEnd, Place_ID);
        }

    }
}
