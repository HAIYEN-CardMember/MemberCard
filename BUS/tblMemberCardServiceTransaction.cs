using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblMemberCardServiceTransaction
    {

        public static List<DTO.tblMemberCardServiceTransaction> GetAll()
        {
            return DAO.tblMemberCardServiceTransaction.Get(0, 0, null, null, 0);
        }

        public static DTO.tblMemberCardServiceTransaction GetByID(int ID)
        {
            return DAO.tblMemberCardServiceTransaction.Get(ID, 0, null, null, 0).FirstOrDefault();
        }


        public static List<DTO.tblMemberCardServiceTransaction> GetByServiceDate(DateTime ServiceDateBegin, DateTime ServiceDateEnd, int Place_ID)
        {
            return DAO.tblMemberCardServiceTransaction.Get(0, 0, ServiceDateBegin, ServiceDateEnd, Place_ID);
        }

        public static List<DTO.tblMemberCardServiceTransaction> GetByServiceDatePointRec(DateTime ServiceDateBegin, DateTime ServiceDateEnd, int Place_ID)
        {
            return DAO.tblMemberCardServiceTransaction.PointRec(0, 0, ServiceDateBegin, ServiceDateEnd, Place_ID);
        }

        public static System.Data.DataTable GetDataByServiceDate(DateTime ServiceDateBegin, DateTime ServiceDateEnd, int Place_ID)
        {
            return DAO.tblMemberCardServiceTransaction.GetData(0, 0, ServiceDateBegin, ServiceDateEnd, Place_ID);
        }

        public static System.Data.DataTable GetDataByServiceDatePointRec(DateTime ServiceDateBegin, DateTime ServiceDateEnd, int Place_ID)
        {
            return DAO.tblMemberCardServiceTransaction.GetDataPointRec(0, 0, ServiceDateBegin, ServiceDateEnd, Place_ID);
        }
        public static List<DTO.tblMemberCardServiceTransaction> GetByCard_ID(int Card_ID)
        {
            return DAO.tblMemberCardServiceTransaction.Get(0, Card_ID, null, null, 0);
        }

        public static int Create(DTO.tblMemberCardServiceTransaction item)
        {
            return DAO.tblMemberCardServiceTransaction.Create(item);
        }

        public static System.Data.DataTable GetViewShare(DateTime ServiceDateBegin, DateTime ServiceDateEnd)
        {
            return DAO.tblMemberCardServiceTransaction.GetViewShare(ServiceDateBegin, ServiceDateEnd);
        }

        public static System.Data.DataTable SharePivotView(DateTime ServiceDateBegin, DateTime ServiceDateEnd)
        {
            return DAO.tblMemberCardServiceTransaction.SharePivotView(ServiceDateBegin, ServiceDateEnd);
        }
    }
}
