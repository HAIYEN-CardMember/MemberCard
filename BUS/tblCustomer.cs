using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblCustomer
    {

        public static List<DTO.tblCustomer> GetAll()
        {
            return DAO.tblCustomer.Get(0, 0);
        }

        public static DTO.tblCustomer GetByID(int customer_id)
        {
            return DAO.tblCustomer.Get(customer_id, 0).FirstOrDefault();
        }

        public static DTO.tblCustomer GetByEmail(int customer_id, string email)
        {
            return DAO.tblCustomer.GetByEmail(customer_id, email).FirstOrDefault();
        }

        public static List<DTO.tblCustomer> GetByGender_ID(int gender_id)
        {
            return DAO.tblCustomer.Get(0, gender_id);
        }

        public static int Create(DTO.tblCustomer item)
        {
            item.FullNameSearch = Utilities.StringExts.ToAscii(item.FullName);
            item.Email = item.Email != null ? item.Email.ToLower() : item.Email;
            return DAO.tblCustomer.Create(item);
        }

        public static int Delete(int customer_id)
        {
            return DAO.tblCustomer.Delete(customer_id, 0);
        }

        public static int DeleteByGender_ID(int gender_id)
        {
            return DAO.tblCustomer.Delete(0, gender_id);
        }
    }
}
