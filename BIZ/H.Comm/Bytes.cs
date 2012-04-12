 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Comm
{
    //参考from :http://www.cnblogs.com/Mainz/archive/2008/04/09/String_Byte_Array_Convert_CSharp.html

    /// <summary>
    ///  Byte类型方法集
    ///  zbw911
    /// </summary>
    public static class Bytes
    {

         private static System.Text.Encoding Encoding = System.Text.Encoding.UTF8;

        /// <summary>
        /// 把 字符串转化为字节数组 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StrToBytes(string str)
        {
            byte[] byteArray = Bytes.Encoding.GetBytes(str);

            return byteArray;
        }

        /// <summary>
        /// 把 字节数组 转化为 字符串
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string BytesToStr(byte[] byteArray)
        {
            string str = Bytes.Encoding.GetString(byteArray);
            return str;
        }

        /// <summary>
        /// 把 字符串转化为字节数组 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string str)
        {
            byte[] byteArray = Bytes.Encoding.GetBytes(str);

            return byteArray;
        }

        /// <summary>
        /// 把 字节数组 转化为 字符串
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string ToStr(this byte[] byteArray)
        {
            string str = Bytes.Encoding.GetString(byteArray);
            return str;
        }

    }
}
