using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblCustomer
    {
        public static List<DTO.tblCustomer> Get(int customer_id, int gender_id)
        {
            List<DTO.tblCustomer> lsArray = new List<DTO.tblCustomer>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", customer_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gender_ID", gender_id));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomer_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomer(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblCustomer> GetByEmail(int customer_id, string email)
        {
            List<DTO.tblCustomer> lsArray = new List<DTO.tblCustomer>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", customer_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", email));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblCustomer_Get_Email", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblCustomer(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static int Create(DTO.tblCustomer item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", item.Customer_ID));
                lsInput[lsInput.Count - 1].Direction = System.Data.ParameterDirection.InputOutput;
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullName", item.FullName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@FullNameSearch", (object)item.FullNameSearch ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gender_ID", item.Gender_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@DOB", (object)item.DOB ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@YOB", (object)item.YOB ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AddressLine1", (object)item.AddressLine1 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AddressLine2", (object)item.AddressLine2 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@MobilePhone", (object)item.MobilePhone ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Phone2", (object)item.Phone2 ?? DBNull.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Email", (object)item.Email ?? DBNull.Value));
                result = conn.ExecuteNonQuery("sp_tblCustomer_Create", lsInput);
                result = item.Customer_ID = (int)lsInput[0].Value;
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Delete(int customer_id, int gender_id)
        {
            int result = 0;
            List<DTO.tblCustomer> lsArray = new List<DTO.tblCustomer>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Customer_ID", customer_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gender_ID", gender_id));
                result = conn.ExecuteNonQuery("sp_tblCustomer_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }
    }
}
