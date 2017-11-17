using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblStaff
    {
        public static List<DTO.tblStaff> GetAll()
        {
            return DAO.tblStaff.Get("");
        }

        public static DTO.tblStaff GetByID(string staffid)
        {
            return DAO.tblStaff.Get(staffid).FirstOrDefault();
        }

        public static int Create(DTO.tblStaff item)
        {
            return DAO.tblStaff.Create(item);
        }

        public static int Create(string StaffID, string StaffName, string accessCode)
        {
            return DAO.tblStaff.Create(StaffID, StaffName, accessCode);
        }

        public static int Delete(string staffid)
        {
            return DAO.tblStaff.Delete(staffid);
        }
        public static System.Data.DataTable Login(string staffid, string accessCode)
        {
            return DAO.tblStaff.Login(staffid, accessCode);
        }
        public static bool ChangePassword(string staffid, string accessCodeOld, string accessCodeNew)
        {
            return DAO.tblStaff.ChangePassword(staffid, accessCodeOld, accessCodeNew);
        }

        public static bool UpdatePassword(string StaffID, string accessCode)
        {
            return DAO.tblStaff.UpdatePassword(StaffID, accessCode);
        }

        public static int Update(string StaffID, string StaffName)
        {
            return DAO.tblStaff.Update(StaffID, StaffName);
        }
    }
}
