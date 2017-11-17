using System;
using System.Collections.Generic;

namespace DAO
{
    public class tblMemberCard
    {
        public static List<DTO.tblMemberCard> Get(int card_id, string card_Code, int customer_ID)
        {
            List<DTO.tblMemberCard> lsArray = new List<DTO.tblMemberCard>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_Code", card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", customer_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCard_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblMemberCard(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static System.Data.DataTable Login(string card_Code, string email, string accessCode)
        {
            ConnectionCRM conn = null;
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardCode", card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", email));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", accessCode));
                dt = conn.ExecuteNonQueryData("sp_tblMemberCard_Login", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static bool ChangePassword(int card_id, string accessCodeOld, string accessCodeNew)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCodeOld", accessCodeOld));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCodeNew", accessCodeNew));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCard_ChangePassword", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }

        public static bool UpdatePassword(int card_id, string accessCode)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", accessCode));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCard_UpdatePassword", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }

        public static bool ResetPassword(string email, string accessCodeNew)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", email));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCodeNew", accessCodeNew));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCard_ResetPassword", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }

        public static int Create(DTO.tblMemberCard item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", item.Card_ID));                
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardType_ID", item.CardType_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", item.Customer_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDate", item.IssueDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssuePlace_ID", item.IssuePlace_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueBy", item.IssueBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ExpDate", item.ExpDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Status_ID", item.Status_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@TotalPoint", item.TotalPoint));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", item.AccessCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", item.EMRCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRPlace_ID", item.EMRPlace_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Notes", item.Notes));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_Code", item.Card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CreateBy", item.CreateBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CreateDate", item.CreateDate));
                //result = conn.ExecuteNonQuery("sp_tblMemberCard_Create", lsInput);
                result = Convert.ToInt32(conn.ExecuteScalar("sp_tblMemberCard_Create", lsInput));                
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Update(int Card_ID, int CardType_ID, int Customer_ID, DateTime IssueDate,int IssuePlace_ID, string IssueBy, DateTime ExpDate, int Status_ID, int TotalPoint, string AccessCode, string EMRCode, int EMRPlace_ID, string Notes, string Card_Code, string UpdateBy)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardType_ID", CardType_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", Customer_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDate", IssueDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssuePlace_ID", IssuePlace_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueBy", IssueBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ExpDate", ExpDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Status_ID", Status_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@TotalPoint", TotalPoint));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", AccessCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", EMRCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRPlace_ID", EMRPlace_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Notes", Notes));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_Code", Card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UpdateBy", UpdateBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UpdateDate", DateTime.Now));
                result = conn.ExecuteNonQuery("sp_tblMemberCard_Update", lsInput);
               // result = Convert.ToInt32(conn.ExecuteScalar("sp_tblMemberCard_Update", lsInput));
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }
   
        public static int Delete(int card_id)
        {
            int result = 0;
            List<DTO.tblMemberCard> lsArray = new List<DTO.tblMemberCard>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                result = conn.ExecuteNonQuery("sp_tblMemberCard_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static bool Switch(int from_Card_ID, int to_Card_ID, string issueBy)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                conn.BeginTransaction();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@From_Card_ID", from_Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@To_Card_ID", to_Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueBy", issueBy));
                result = conn.ExecuteNonQuery("sp_tblMemberCard_Switch", lsInput) > 0;
                conn.Commit();
            }
            catch (Exception ex) { conn.RollBack(); }
            finally { conn.Close(); }
            return result;
        }

        public static bool MemberCard_UpdateStatus(int card_id)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCard_UpdateStatus", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }
    }
}