using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class StringExts
    {
        public static string ToAscii(string unicode)
        {
            unicode = unicode.ToLower();
            unicode = Regex.Replace(unicode, "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            unicode = Regex.Replace(unicode, "[óòỏõọôồốổỗộơớờởỡợ]", "o");
            unicode = Regex.Replace(unicode, "[éèẻẽẹêếềểễệ]", "e");
            unicode = Regex.Replace(unicode, "[íìỉĩị]", "i");
            unicode = Regex.Replace(unicode, "[úùủũụưứừửữự]", "u");
            unicode = Regex.Replace(unicode, "[ýỳỷỹỵ]", "y");
            unicode = Regex.Replace(unicode, "[đ]", "d");
            //unicode = Regex.Replace(unicode, "[-\\s+/]+", "-");
            unicode = Regex.Replace(unicode, "\\W+", "-"); //Nếu bạn muốn thay dấu khoảng trắng thành dấu "_" hoặc dấu cách " " thì thay kí tự bạn muốn vào đấu "-"
            return unicode.ToUpper();
        }

        public static string RandomAccessCode()
        {
            string result = "";
            Random rd = new Random();
            for (int i = 0; i < 5; i++)
            {
                switch (rd.Next(0, 2))
                {
                    case 0:
                        result += (char)rd.Next(65, 90);
                        break;
                    case 1:
                        result += (char)rd.Next(97, 122);
                        break;
                    case 2:
                        result += (char)rd.Next(48, 57);
                        break;
                    default:
                        break;
                }

            }
            return result;
        }
    }
}
