using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tblServiceTransaction
    {
        public int ID { get; set; }
        public int Card_ID { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public int ServicePlace_ID { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceAmount { get; set; }
        public int Increase_Decrease { get; set; }
        public bool AutoTransferInput { get; set; }
        public int PointRule_ID { get; set; }
        public int? PointRec { get; set; }

        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime? CreateDate { get; set; }
        public System.DateTime? UpdateDate { get; set; }
        public int ServiceAmount_Audit { get; set; }

        public tblServiceTransaction()
        {
            ID = 0;
            Card_ID = 0;
            ServiceDate = DateTime.Now;
            ServicePlace_ID = 0;
            ServiceDescription = "";
            ServiceAmount = 0;
            Increase_Decrease = 0;
            AutoTransferInput = false;
            PointRule_ID = 0;
            PointRec = (int?)null;
            CreateBy = "";
            UpdateBy = "";
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            ServiceAmount_Audit = 0;

        }

        public tblServiceTransaction(System.Data.DataRow row)
        {
            ID = row["ID"].ToString() != "" ? Convert.ToInt32(row["ID"]) : 0;
            Card_ID = row["Card_ID"].ToString() != "" ? Convert.ToInt32(row["Card_ID"]) : 0;
            ServiceDate = row["ServiceDate"].ToString() != "" ? Convert.ToDateTime(row["ServiceDate"]) : DateTime.Now;
            ServicePlace_ID = row["ServicePlace_ID"].ToString() != "" ? Convert.ToInt32(row["ServicePlace_ID"]) : 0;
            ServiceDescription = row["ServiceDescription"].ToString();
            ServiceAmount = row["ServiceAmount"].ToString() != "" ? Convert.ToInt32(row["ServiceAmount"]) : 0;
            Increase_Decrease = row["Increase_Decrease"].ToString() != "" ? Convert.ToInt32(row["Increase_Decrease"]) : 0;
            AutoTransferInput = row["AutoTransferInput"].ToString() != "" ? Convert.ToBoolean(row["AutoTransferInput"]) : false;
            PointRule_ID = row["PointRule_ID"].ToString() != "" ? Convert.ToInt32(row["PointRule_ID"]) : 0;
            PointRec = row["PointRec"].ToString() != "" ? Convert.ToInt32(row["PointRec"]) : (int?)null;
            CreateBy = row["CreateBy"].ToString();
            UpdateBy = row["UpdateBy"].ToString();
            CreateDate = row["CreateDate"].ToString() != "" ? Convert.ToDateTime(row["CreateDate"]) : DateTime.Now;
            UpdateDate = row["UpdateDate"].ToString() != "" ? Convert.ToDateTime(row["UpdateDate"]) : DateTime.Now;
            ServiceAmount_Audit = row["ServiceAmount_Audit"].ToString() != "" ? Convert.ToInt32(row["ServiceAmount_Audit"]) : 0;
        }
    }
}
