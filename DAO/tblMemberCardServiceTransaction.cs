using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblMemberCardServiceTransaction
    {
        public static List<DTO.tblMemberCardServiceTransaction> Get(int ID, int Card_ID, DateTime? ServiceDateBegin, DateTime? ServiceDateEnd, int Place_ID)
        {
            List<DTO.tblMemberCardServiceTransaction> lsArray = new List<DTO.tblMemberCardServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCardServiceTransaction_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblMemberCardServiceTransaction(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static List<DTO.tblMemberCardServiceTransaction> PointRec(int ID, int Card_ID, DateTime? ServiceDateBegin, DateTime? ServiceDateEnd, int Place_ID)
        {
            List<DTO.tblMemberCardServiceTransaction> lsArray = new List<DTO.tblMemberCardServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblMemberCardServiceTransaction_PointRec", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblMemberCardServiceTransaction(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static System.Data.DataTable GetData(int ID, int Card_ID, DateTime? ServiceDateBegin, DateTime? ServiceDateEnd, int Place_ID)
        {
            System.Data.DataTable dt = null;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                dt = conn.ExecuteNonQueryData("sp_tblMemberCardServiceTransaction_Get", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static System.Data.DataTable GetDataPointRec(int ID, int Card_ID, DateTime? ServiceDateBegin, DateTime? ServiceDateEnd, int Place_ID)
        {
            System.Data.DataTable dt = null;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", Card_ID));
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", Place_ID));
                dt = conn.ExecuteNonQueryData("sp_tblMemberCardServiceTransaction_PointRec", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static int Create(DTO.tblMemberCardServiceTransaction item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", item.Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDate", item.ServiceDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PlaceName", item.PlaceName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDescription", item.ServiceDescription));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Increase_Decrease", item.Increase_Decrease));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Description", item.Description));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRec", item.PointRec));
                result = conn.ExecuteNonQuery("sp_tblMemberCardServiceTransaction_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Delete()
        {
            int result = 0;
            List<DTO.tblMemberCardServiceTransaction> lsArray = new List<DTO.tblMemberCardServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                result = conn.ExecuteNonQuery("sp_tblMemberCardServiceTransaction_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static System.Data.DataTable GetViewShare(DateTime? ServiceDateBegin, DateTime? ServiceDateEnd)
        {
            System.Data.DataTable dt = null;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                dt = conn.ExecuteNonQueryData("sp_tblServiceTransaction_ViewShare", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static System.Data.DataTable SharePivotView(DateTime? ServiceDateBegin, DateTime? ServiceDateEnd)
        {
            System.Data.DataTable dt = null;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                if (ServiceDateBegin != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateBegin", ServiceDateBegin.Value));
                if (ServiceDateEnd != null)
                    lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDateEnd", ServiceDateEnd.Value));
                dt = conn.ExecuteNonQueryData("sp_ServiceTransactionSharePivotView", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }
    }
}
