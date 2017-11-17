using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tblMemberCardServiceTransaction
    {
        public int No_ { get; set; }
        public int ID { get; set; }
        public int Card_ID { get; set; }
        public string Card_Code { get; set; }
        public string FullName { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAtName { get; set; }
        public string SharePlaceName { get; set; }
        public string ServiceDescription { get; set; }
        public string Increase_Decrease { get; set; }
        public string Description { get; set; }
        public int? PointRec { get; set; }
        public int? ServiceAmount { get; set; }
        public int ShareAmount { get; set; }
        //public int? MAT304 { get; set; }
      //  public int? MATHYEC { get; set; }
      //  public int? MATANSINH { get; set; }

        public tblMemberCardServiceTransaction()
        {
            No_ = 0;
            ID = 0;
            Card_ID = 0;
            Card_Code = "";
            FullName = "";
            ServiceDate = DateTime.Now;
            PlaceName = "";
            ServiceDescription = "";
            Increase_Decrease = "";
            Description = "";
            ServiceAmount = (int?)null;
            PointRec = (int?)null;
           // MAT304 = (int?)null;
          //  MATHYEC = (int?)null;
           // MATANSINH = (int?)null; 
        }

        public tblMemberCardServiceTransaction(System.Data.DataRow row)
        {
            No_ = row["No_"].ToString() != "" ? Convert.ToInt32(row["No_"]) : 0;
            ID = row["ID"].ToString() != "" ? Convert.ToInt32(row["ID"]) : 0;
            Card_ID = row["Card_ID"].ToString() != "" ? Convert.ToInt32(row["Card_ID"]) : 0;
            Card_Code = row["Card_Code"].ToString();
            FullName = row["FullName"].ToString();
            ServiceDate = row["ServiceDate"].ToString() != "" ? Convert.ToDateTime(row["ServiceDate"]) : DateTime.Now;
            PlaceName = row["PlaceName"].ToString();
            //PlaceAtName = row["PaymentAtName"].ToString();
            //PlaceAtName = row["SharePlaceName"].ToString();
            ServiceDescription = row["ServiceDescription"].ToString();
            ServiceAmount = row["ServiceAmount"].ToString() != "" ? Convert.ToInt32(row["ServiceAmount"]) : (int?)null;
            Increase_Decrease = row["Increase_Decrease"].ToString();
            Description = row["Description"].ToString();
            PointRec = row["PointRec"].ToString() != "" ? Convert.ToInt32(row["PointRec"]) : (int?)null;
            //PointRec = row["ShareAmount"].ToString() != "" ? Convert.ToInt32(row["PointRec"]) : (int?)null;
           // MAT304 = row["MAT304"].ToString() != "" ? Convert.ToInt32(row["MAT304"]) : (int?)null;
           // MATHYEC = row["MATHYEC"].ToString() != "" ? Convert.ToInt32(row["MATHYEC"]) : (int?)null;
           // MATANSINH = row["MATANSINH"].ToString() != "" ? Convert.ToInt32(row["MATANSINH"]) : (int?)null;


        }

    }
}
