using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.HbaseProvider;
using H.Comm;

namespace H.BLL
{
    /// <summary>
    /// 用户订单方法
    /// added by zbw911
    /// </summary>
    public class UserOrder
    {
        private static string tableName = "userorder";


        /// <summary>
        /// 插入用户订单
        /// 
        /// : create 'userorder','o'
        /// </summary>
        public static void AddUserOrder(string userid, string orderid, string productid, string pip, int count, double price, double money, DateTime ordertime)
        {
            using (var hclient = HBaseClientPool.GetHclient())
            {
                string desctime = H.Comm.TimeUtility.DescTimeStamp(ordertime).ToString();
                string rowkey = H.Comm.StringUtility.FixedLenString(userid, 20) + H.Comm.StringUtility.FixedLenString(productid, 20) + desctime;

                hclient.Client.mutateRow(tableName.ToBytes(), rowkey.ToBytes(),
                    new List<Apache.Hadoop.Hbase.Mutation> { 
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:uid".ToBytes(), Value = userid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:oid".ToBytes(), Value = orderid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:pid".ToBytes(), Value = productid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:pip".ToBytes(), Value = pip.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:cnt".ToBytes(), Value = count.ToString().ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:pri".ToBytes(), Value = price.ToString().ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:mny".ToBytes(), Value = money.ToString().ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "o:tim".ToBytes(), Value = ordertime.ToString().ToBytes() }
                });
            }
        }
    }
}
