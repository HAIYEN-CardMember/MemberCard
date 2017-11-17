using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class tblServiceTransaction
    {
        public static List<DTO.tblServiceTransaction> Get(int id, int card_id, int serviceplace_id, int pointrule_id)
        {
            List<DTO.tblServiceTransaction> lsArray = new List<DTO.tblServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServicePlace_ID", serviceplace_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRule_ID", pointrule_id));
                System.Data.DataTable dt = conn.ExecuteNonQueryData("sp_tblServiceTransaction_Get", lsInput);
                foreach (System.Data.DataRow row in dt.Rows) { lsArray.Add(new DTO.tblServiceTransaction(row)); }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return lsArray;
        }

        public static int Create(DTO.tblServiceTransaction item)
        {
            int result = 0;
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", item.ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", item.Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDate", item.ServiceDate));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServicePlace_ID", item.ServicePlace_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDescription", item.ServiceDescription));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceAmount", item.ServiceAmount));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Increase_Decrease", item.Increase_Decrease));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@AutoTransferInput", item.AutoTransferInput));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRule_ID", item.PointRule_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRec", item.PointRec));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CreateBy", item.CreateBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@CreateDate", item.CreateDate));             
                result = conn.ExecuteNonQuery("sp_tblServiceTransaction_Create", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Delete(int id, int card_id, int serviceplace_id, int pointrule_id, string UpdateBy)
        {
            int result = 0;
            List<DTO.tblServiceTransaction> lsArray = new List<DTO.tblServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ID", id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServicePlace_ID", serviceplace_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRule_ID", pointrule_id));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UpdateBy", UpdateBy));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@UpdateDate", DateTime.Now));
                result = conn.ExecuteNonQuery("sp_tblServiceTransaction_Delete", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }

        public static int Gift(int card_ID, string Card_Code, int servicePlace_ID, int gift_Card_ID, string Gift_Card_Code, DateTime serviceDate, string ServiceDescription, string Gif_ServiceDescription, int pointRec)
        {
            int result = 0;
            List<DTO.tblServiceTransaction> lsArray = new List<DTO.tblServiceTransaction>();
            ConnectionCRM conn = null;
            try
            {
                conn = new ConnectionCRM();
                conn.Open();
                List<System.Data.SqlClient.SqlParameter> lsInput = new List<System.Data.SqlClient.SqlParameter>();
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_ID", card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Card_Code", Card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServicePlace_ID", servicePlace_ID)); 

                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gift_Card_ID", gift_Card_ID));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gift_Card_Code", Gift_Card_Code));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDate", serviceDate));

                lsInput.Add(new System.Data.SqlClient.SqlParameter("@ServiceDescription", ServiceDescription));
                lsInput.Add(new System.Data.SqlClient.SqlParameter("@Gif_ServiceDescription", Gif_ServiceDescription));

                lsInput.Add(new System.Data.SqlClient.SqlParameter("@PointRec", pointRec));
                result = conn.ExecuteNonQuery("sp_tblServiceTransaction_GiftPoint", lsInput);
            }
            catch (Exception ex) { result = -1; }
            finally { conn.Close(); }
            return result;
        }


    }
}
