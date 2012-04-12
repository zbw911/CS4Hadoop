using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hbase.Test
{
    //from :http://www.cnblogs.com/Mainz/archive/2008/04/09/String_Byte_Array_Convert_CSharp.html

    public static class Unitl
    {
        public static byte[] StrToBytes(string str)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            return byteArray;
        }

        public static string BytesToStr(byte[] byteArray)
        {
            string str = System.Text.Encoding.Default.GetString(byteArray);
            return str;
        }


        public static byte[] ToBytes(this string str)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            return byteArray;
        }

        
    }
}
