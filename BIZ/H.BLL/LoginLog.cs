using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.HbaseProvider;
using H.Comm;
using Apache.Hadoop.Hbase;
namespace H.BLL
{
    /// <summary>
    /// 用户登录日志，记录于hbase
    /// </summary>
    public class LoginLog
    {

        private static string tableName = "loginlog";

        /// <summary>
        /// 将日志插入 hbase
        /// row {u:uid,u:ip,u:lt,u:r}
        /// 
        /// hbase script: create 'loginlog','u'
        /// </summary>
        public static void AddLog(string userid, string ip, DateTime logintime, bool result)
        {
            using (var hclient = HBaseClientPool.GetHclient())
            {
                string strtime = H.Comm.TimeUtility.DescTimeStamp(logintime).ToString();
                string row = H.Comm.StringUtility.FixedLenString(userid, 20) + strtime;

                hclient.Client.mutateRow(tableName.ToBytes(), row.ToBytes(),
                    new List<Apache.Hadoop.Hbase.Mutation> { 
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:uid".ToBytes(), Value = userid.ToBytes() },
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:ip".ToBytes(), Value = ip.ToBytes() },
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:lt".ToBytes(), Value = logintime.ToString().ToBytes() },
                 new Apache.Hadoop.Hbase.Mutation{ Column= "u:r".ToBytes(), Value = Convert.ToInt16(result).ToString().ToBytes() }
                });
            }

        }

        //public static void PoolAddLog(string userid, string ip, DateTime logintime, bool result)
        //{
        //    using (var hclient = HBaseClientPool.GetHclient())
        //    {
        //        string strtime = H.Comm.TimeUtility.DescTimeStamp(logintime).ToString();
        //        string row = H.Comm.StringUtility.FixedLenString(userid, 20) + strtime;

        //        hclient.Client.mutateRow(tableName.ToBytes(), row.ToBytes(),
        //            new List<Apache.Hadoop.Hbase.Mutation> { 
        //        new Apache.Hadoop.Hbase.Mutation{ Column= "u:uid".ToBytes(), Value = userid.ToBytes() },
        //        new Apache.Hadoop.Hbase.Mutation{ Column= "u:ip".ToBytes(), Value = ip.ToBytes() },
        //        new Apache.Hadoop.Hbase.Mutation{ Column= "u:lt".ToBytes(), Value = logintime.ToString().ToBytes() },
        //         new Apache.Hadoop.Hbase.Mutation{ Column= "u:r".ToBytes(), Value = Convert.ToInt16(result).ToString().ToBytes() }
        //        });
        //    }


        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<TRowResult> GetLog(string userid, int top = 100)
        {

            string prefixrow = H.Comm.StringUtility.FixedLenString(userid, 20);

            using (var hclient = HBaseClientPool.GetHclient())
            {
                var scanid = hclient.Client.scannerOpenWithPrefix(tableName.ToBytes(), prefixrow.ToBytes(), new List<byte[]> { "u".ToBytes() });

                var list = hclient.Client.scannerGetList(scanid, top);

                return list;

            }
        }


        // IPstat 表 : create 'ipstat','r'
        public static List<TRowResult> ScanIp(int top = 1000)
        {
            using (var hclient = HBaseClientPool.GetHclient())
            {
                var scanid = hclient.Client.scannerOpen("ipstat".ToBytes(), "192.".ToBytes(), new List<byte[]> { "r".ToBytes() });

                var list = hclient.Client.scannerGetList(scanid, top);

                return list;

            }
        }
    }
}
