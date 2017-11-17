using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class ExportData
    {
        public static string[] GetTableName(string[] s)
        {
            string str = "";
            bool isInsert = false;
            foreach (string s1 in s)
            {
                if (isInsert)
                {
                    if (s1[0] == '[')
                        break;
                    else
                        str += s1;
                }
                else
                    isInsert = s1 == "[TableName]";
            }
            return str.Split(';');
        }


        public static string GetSQL(string[] s)
        {
            string str = "";
            bool isInsert = false;
            foreach (string s1 in s)
            {
                if (isInsert)
                {
                    if (s1[0] == '[')
                        break;
                    else
                        str += s1 + Environment.NewLine;
                }
                else
                    isInsert = s1 == "[SQL]";
            }
            return str;
        }

        public static void Save(System.Data.DataSet ds, string fileName)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            if (System.IO.File.Exists(file.FullName))
                System.IO.File.Delete(file.FullName);
            if (ds.Tables.Count > 0)
            {
                using (ExcelPackage pck = new ExcelPackage(file))
                {
                    foreach (System.Data.DataTable dt in ds.Tables)
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(dt.TableName);
                        ws.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Medium14);
                        int i = 1;
                        foreach (System.Data.DataColumn col in dt.Columns)
                        {

                            ExcelColumn excelColumn = ws.Column(i++);
                            SetStyle(excelColumn, col);
                            excelColumn.AutoFit();
                        }
                    }
                    pck.Save();
                }
            }
        }

        public static void SetStyle(ExcelColumn excelColumn, System.Data.DataColumn col)
        {
            switch (col.DataType.ToString())
            {
                case "System.DateTime":

                    if (col.ColumnName.ToLower().Contains("datetime"))
                        excelColumn.Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    else if (col.ColumnName.ToLower().Contains("time"))
                        excelColumn.Style.Numberformat.Format = "HH:mm:ss";
                    else
                        excelColumn.Style.Numberformat.Format = "dd/MM/yyyy";
                    break;
                case "System.Decimal":
                    excelColumn.Style.Numberformat.Format = "_(* #,##0.00_);_(* (#,##0.00);_(* \" - \"??_);_(@_)";
                    break;
                case "System.Int32":
                    excelColumn.Style.Numberformat.Format = "_(* #,##0_);_(* (#,##0);_(* \" - \"??_);_(@_)";
                    break;
                default:
                    break;
            }
        }
    }
}
