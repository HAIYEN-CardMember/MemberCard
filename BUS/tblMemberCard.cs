using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class tblMemberCard
    {
        public static List<DTO.tblMemberCard> GetAll()
        {
            return DAO.tblMemberCard.Get(0, "", 0);
        }

        public static DTO.tblMemberCard GetByID(int card_id)
        {
            return DAO.tblMemberCard.Get(card_id, "", 0).FirstOrDefault();
        }

        public static DTO.tblMemberCard GetByCardCode(string card_Code)
        {
            return DAO.tblMemberCard.Get(0, card_Code, 0).FirstOrDefault();
        }

        public static List<DTO.tblMemberCard> GetByCustomerID(int customer_ID)
        {
            return DAO.tblMemberCard.Get(0, "", customer_ID);
        }

        public static int Create(DTO.tblMemberCard item)
        {
            int rerult = DAO.tblMemberCard.Create(item);
            if (rerult > 0)
            {

            }
            return rerult;
            //return DAO.tblMemberCard.Create(item);
        }

        /*
        public static int Update_Old(DTO.tblMemberCard item)
        {
            int rerult = DAO.tblMemberCard.Update(item);
            if (rerult > 0)
            {

            }
            return rerult;
            //return DAO.tblMemberCard.Create(item);
        }

        */

        public static int Update(int Card_ID, int CardType_ID, int Customer_ID, DateTime IssueDate, int IssuePlace_ID, string IssueBy, DateTime ExpDate, int Status_ID, int TotalPoint, string AccessCode, string EMRCode, int EMRPlace_ID, string Notes, string Card_Code, string UpdateBy)
        {
            return DAO.tblMemberCard.Update(Card_ID, CardType_ID, Customer_ID, IssueDate, IssuePlace_ID, IssueBy, ExpDate, Status_ID, TotalPoint, AccessCode, EMRCode, EMRPlace_ID, Notes, Card_Code, UpdateBy);
        }

        public static int Delete(int card_id)
        {
            return DAO.tblMemberCard.Delete(card_id);
        }

        public static System.Data.DataTable Login(string card_Code, string email, string accessCode)
        {
            return DAO.tblMemberCard.Login(card_Code, email, accessCode);
        }

        public static bool ChangePassword(int card_id, string accessCodeOld, string accessCodeNew)
        {
            return DAO.tblMemberCard.ChangePassword(card_id, accessCodeOld, accessCodeNew);
        }

        public static bool UpdatePassword(int card_id, string accessCode)
        {
            return DAO.tblMemberCard.UpdatePassword(card_id, accessCode);
        }

        public static bool ResetPassword(string email, string accessCodeNew)
        {
            return DAO.tblMemberCard.ResetPassword(email, accessCodeNew);
        }

        public static bool Switch(int from_Card_ID, int to_Card_ID, string issueBy)
        {
            return DAO.tblMemberCard.Switch(from_Card_ID, to_Card_ID, issueBy);
        }

        public static bool MemberCard_UpdateStatus(int card_id)
        {
            return DAO.tblMemberCard.MemberCard_UpdateStatus(card_id);
        }
    }
}