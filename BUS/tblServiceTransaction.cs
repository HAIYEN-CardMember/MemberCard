using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class tblServiceTransaction
    {

        public static List<DTO.tblServiceTransaction> GetAll()
        {
            return DAO.tblServiceTransaction.Get(0, 0, 0, 0);
        }

        public static List<DTO.tblServiceTransaction> Get(int id, int card_id, int serviceplace_id, int pointrule_id)
        {
            return DAO.tblServiceTransaction.Get(id, card_id, serviceplace_id, pointrule_id);
        }

        public static DTO.tblServiceTransaction GetByID(int id)
        {
            return DAO.tblServiceTransaction.Get(id, 0, 0, 0).FirstOrDefault();
        }

        public static List<DTO.tblServiceTransaction> GetByCard_ID(int card_id)
        {
            return DAO.tblServiceTransaction.Get(0, card_id, 0, 0);
        }

        public static List<DTO.tblServiceTransaction> GetByServicePlace_ID(int serviceplace_id)
        {
            return DAO.tblServiceTransaction.Get(0, 0, serviceplace_id, 0);
        }

        public static List<DTO.tblServiceTransaction> GetByPointRule_ID(int pointrule_id)
        {
            return DAO.tblServiceTransaction.Get(0, 0, 0, pointrule_id);
        }

        public static int Create(DTO.tblServiceTransaction item)
        {
            return DAO.tblServiceTransaction.Create(item);
        }

        public static int Delete(int id, string UpdateBy)
        {
            return DAO.tblServiceTransaction.Delete(id, 0, 0, 0, UpdateBy);
        }

        public static int DeleteByCard_ID(int card_id, string UpdateBy)
        {
            return DAO.tblServiceTransaction.Delete(0, card_id, 0, 0, UpdateBy);
        }

        public static int DeleteByServicePlace_ID(int serviceplace_id, string UpdateBy)
        {
            return DAO.tblServiceTransaction.Delete(0, 0, serviceplace_id, 0, UpdateBy);
        }

        public static int DeleteByPointRule_ID(int pointrule_id, string UpdateBy)
        {
            return DAO.tblServiceTransaction.Delete(0, 0, 0, pointrule_id, UpdateBy);
        }

        public static int Gift(int card_ID, string Card_Code, int servicePlace_ID, int gift_Card_ID, string Gift_Card_Code, DateTime serviceDate, string ServiceDescription, string Gif_ServiceDescription, int pointRec)
        {
            return DAO.tblServiceTransaction.Gift(card_ID, Card_Code, servicePlace_ID, gift_Card_ID, Gift_Card_Code, serviceDate, ServiceDescription, Gif_ServiceDescription,  pointRec);
        }

    }
}
