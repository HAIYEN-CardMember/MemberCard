using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblCustomerMemberCard
    {
        public static List<DTO.tblCustomerMemberCard> Get(string FullNameSearch, int Card_ID, string CardCode, string EMRCode, DateTime? IssueDateBegin, DateTime? IssueDateEnd, int Place_ID)
        {
            List<DTO.tblCustomerMemberCard> lsArray = new List<DTO.tblCustomerMemberCard>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", FullNameSearch));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardCode", CardCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", EMRCode));
                if (IssueDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateBegin", IssueDateBegin.Value));
                if (IssueDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateEnd", IssueDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCard_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCard(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblCustomerMemberCard> GetSearchPhone(string FullNameSearch, int Card_ID, string CardCode, string EMRCode, string MobilePhone, DateTime? IssueDateBegin, DateTime? IssueDateEnd, int Place_ID)
        {
            List<DTO.tblCustomerMemberCard> lsArray = new List<DTO.tblCustomerMemberCard>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", FullNameSearch));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CardCode", CardCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", EMRCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@MobilePhone", MobilePhone));
                if (IssueDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateBegin", IssueDateBegin.Value));
                if (IssueDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateEnd", IssueDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCard_GetSearchPhone", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomerMemberCard(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static System.Data.DataTable GetData(string FullNameSearch, int Card_ID, string EMRCode, DateTime? IssueDateBegin, DateTime? IssueDateEnd, int Place_ID)
        {
            System.Data.DataTable dt = null;

            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", FullNameSearch));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", EMRCode));
                if (IssueDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateBegin", IssueDateBegin.Value));
                if (IssueDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDateEnd", IssueDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                dt = conn.ExecuteNonQueryData("sp_tblCustomerMemberCard_Get", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static int Create(DTO.tblCustomerMemberCard item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", item.Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", item.Customer_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullName", item.FullName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", item.FullNameSearch));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@EMRCode", item.EMRCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@IssueDate", item.IssueDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ExpDate", item.ExpDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PlaceName", item.PlaceName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@TotalPoint", item.TotalPoint));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Description", item.Description));
                result = conn.ExecuteNonQuery("sp_tblCustomerMemberCard_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Delete()
        {
            int result = 0;
            List<DTO.tblCustomerMemberCard> lsArray = new List<DTO.tblCustomerMemberCard>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                result = conn.ExecuteNonQuery("sp_tblCustomerMemberCard_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }
    }
}
