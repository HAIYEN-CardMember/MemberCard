using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblStaff
    {
        public static List<DTO.tblStaff> Get(string staffid)
        {
            List<DTO.tblStaff> lsArray = new List<DTO.tblStaff>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", staffid));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblStaff_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblStaff(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static int Create(DTO.tblStaff item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", item.StaffID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffName", item.StaffName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", item.AccessCode));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Place_ID", item.Place_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AdminRight", item.AdminRight));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UPDMember", item.UPDMember));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UPDServiceTransaction", item.UPDServiceTransaction));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UPDPaymentTransaction", item.UPDPaymentTransaction));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UPDPointRule", item.UPDPointRule));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UPDChangeCard", item.UPDChangeCard));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@RPTMember", item.RPTMember));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@RPTServiceTransaction", item.RPTServiceTransaction));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@RPTPaymentTransaction", item.RPTPaymentTransaction));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@RPTReportIncrease_Decrease", item.RPTReportIncrease_Decrease));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@RPTReportServiceAmount", item.RPTReportServiceAmount));
                result = conn.ExecuteNonQuery("sp_tblStaff_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Create(string StaffID, string StaffName, string accessCode)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", StaffID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffName", StaffName));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", accessCode));
                result = conn.ExecuteNonQuery("sp_tblStaff_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Delete(string staffid)
        {
            int result = 0;
            List<DTO.tblStaff> lsArray = new List<DTO.tblStaff>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", staffid));
                result = conn.ExecuteNonQuery("sp_tblStaff_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static System.Data.DataTable Login(string staffid, string accessCode)
        {
            ConnectionCRM conn = null;
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", staffid));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", accessCode));
                dt = conn.ExecuteNonQueryData("sp_tblStaff_Login", lsInput);
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dt;
        }

        public static bool ChangePassword(string staffid, string accessCodeOld, string accessCodeNew)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Staff_ID", staffid));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCodeOld", accessCodeOld));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCodeNew", accessCodeNew));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblStaff_ChangePassword", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }

        public static bool UpdatePassword(string StaffID, string accessCode)
        {
            ConnectionCRM conn = null;
            bool result = false;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", StaffID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AccessCode", accessCode));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblStaff_UpdatePassword", lsInput);
                result = dt.Rows.Count > 0;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return result;
        }

        public static int Update(string StaffID, string StaffName)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffID", StaffID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@StaffName", StaffName));
                result = conn.ExecuteNonQuery("sp_tblStaff_Update", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }
    }
}
