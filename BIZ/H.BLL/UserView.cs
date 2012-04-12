using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.HbaseProvider;
using H.Comm;


namespace H.BLL
{
    public class UserView
    {
        //private static string tableName = "mainpageview";

        /// <summary>
        /// 用户的来访日志
        /// 
        /// create 'mpv','m'
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="toid"></param>
        /// <param name="dt"></param>
        public static void MainPageview(string userid, string toid, DateTime dt)
        {
            string tableName = "mpv";

            using (var hclient = HBaseClientPool.GetHclient())
            {
                string desctime = H.Comm.TimeUtility.DescTimeStamp(dt).ToString();

                string rowkey = H.Comm.StringUtility.FixedLenString(userid, 20)
                    + H.Comm.StringUtility.FixedLenString(toid, 20)
                    + desctime;

                hclient.Client.mutateRow(tableName.ToBytes(), rowkey.ToBytes(),
                    new List<Apache.Hadoop.Hbase.Mutation> { 
                    new Apache.Hadoop.Hbase.Mutation{ Column= "m:uid".ToBytes(), Value = userid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "m:tid".ToBytes(), Value = toid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "m:dt".ToBytes(), Value = dt.ToString().ToBytes() }
                });
            }
        }

        /// <summary>
        /// 用户的行为跟踪
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="url"></param>
        /// <param name="dt"></param>
        /// <param name="toid"></param>
        public static void TrackeUserAction(string userid, string url, string referer, DateTime dt, string toid = "")
        {
            string tableName = "tracku";

            using (var hclient = HBaseClientPool.GetHclient())
            {
                string desctime = H.Comm.TimeUtility.DescTimeStamp(dt).ToString();

                string rowkey = H.Comm.StringUtility.FixedLenString(userid, 20)
                    + desctime;

                hclient.Client.mutateRow(tableName.ToBytes(), rowkey.ToBytes(),
                    new List<Apache.Hadoop.Hbase.Mutation> { 
                    new Apache.Hadoop.Hbase.Mutation{ Column= "t:uid".ToBytes(), Value = userid.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "t:url".ToBytes(), Value = url.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "t:dt".ToBytes(), Value = dt.ToString().ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "t:ref".ToBytes(), Value = referer.ToBytes() },
                    new Apache.Hadoop.Hbase.Mutation{ Column= "t:toid".ToBytes(), Value = toid.ToBytes() }
                });
            }
        }
    }
}
