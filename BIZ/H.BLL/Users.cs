using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.BLL
{
    /// <summary>
    /// 用户关系输入
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 一个用户与另一个用户的联系，这里只考虑一个单向的关系
        /// </summary>
        /// <param name="fromUid"></param>
        /// <param name="toUid"></param>
        /// <param name="UpdateTime"></param>
        public static void AddRelation(string fromUid, string toUid, DateTime UpdateTime)
        {
        }
    }
}
