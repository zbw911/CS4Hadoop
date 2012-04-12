using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Comm
{
    /// <summary>
    /// 字串类
    /// added by zbw911
    /// </summary>
    public class StringUtility
    {
        /// <summary>
        /// 返回固定长度的字串,左补0
        /// </summary>
        /// <param name="input"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string FixedLenString(string input,int len)
        {
            input = input ?? "";

            if (input.Length > len) throw new ArgumentOutOfRangeException("input", "长度大于" + len);

            return input.PadLeft(len, '0');
            //Console.WriteLine("123456".PadLeft(5, '0'));
        }
    }
}
