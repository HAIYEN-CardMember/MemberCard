using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblCustomerMemberCardData
    {
        public static List<DTO.tblCustomerMemberCardData> GetAll()
        {
            return DAO.tblCustomerMemberCardData.Get(0, 0);
        }

        public static DTO.tblCustomerMemberCardData GetByID(int card_id)
        {
            return DAO.tblCustomerMemberCardData.Get(card_id, 0).FirstOrDefault();
        }

        public static List<DTO.tblCustomerMemberCardData> GetByCustomerID(int customer_ID)
        {
            return DAO.tblCustomerMemberCardData.Get(0, customer_ID);
        }

        public static List<DTO.tblCustomerMemberCardData> GetByCustomerPhone(string customer_MobilePhone)
        {
            return DAO.tblCustomerMemberCardData.GetByPhone(customer_MobilePhone);
        }

        public static List<DTO.tblCustomerMemberCardData> GetByCustomerEmail(string email)
        {
            return DAO.tblCustomerMemberCardData.GetByEmail(email);
        }

        public static List<DTO.tblCustomerMemberCardData> GetByCardCode(string card_Code)
        {
            return DAO.tblCustomerMemberCardData.GetByCardCode(card_Code);
        }

        public static int Create(DTO.tblCustomerMemberCardData item)
        {
            return DAO.tblCustomerMemberCardData.Create(item);
        }
    }
}
