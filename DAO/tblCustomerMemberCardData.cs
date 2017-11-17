using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblCustomerMemberCardData
    {
        public static List<DTO.tblCustomerMemberCardData> Get(int card_id, int customer_ID)
        {
            List<DTO.tblCustomerMemberCardData> lsArray = new List<DTO.tblCustomerMemberCardData>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", customer_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCardData_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCardData(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblCustomerMemberCardData> GetByPhone(string customer_MobilePhone)
        {
            List<DTO.tblCustomerMemberCardData> lsArray = new List<DTO.tblCustomerMemberCardData>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@MobilePhone", customer_MobilePhone));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCardData_GetByPhone", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCardData(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblCustomerMemberCardData> GetByEmail(string email)
        {
            List<DTO.tblCustomerMemberCardData> lsArray = new List<DTO.tblCustomerMemberCardData>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", email));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCardData_GetByEmail", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCardData(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblCustomerMemberCardData> GetByCardCode(string card_Code)
        {
            List<DTO.tblCustomerMemberCardData> lsArray = new List<DTO.tblCustomerMemberCardData>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardCode", card_Code));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCardData_GetByCardCode", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCardData(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static int Create(DTO.tblCustomerMemberCardData item)
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
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullName", item.FullName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", (object)item.FullNameSearch ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gender_ID", item.Gender_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@DOB", (object)item.DOB ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@YOB", (object)item.YOB ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AddressLine1", (object)item.AddressLine1 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AddressLine2", (object)item.AddressLine2 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@MobilePhone", (object)item.MobilePhone ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Phone2", (object)item.Phone2 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", item.Email));
                result = conn.ExecuteNonQuery("tblCustomerMemberCardData_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }
    }
}
