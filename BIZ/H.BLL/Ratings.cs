using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.HbaseProvider;
using H.Comm;

namespace H.BLL
{
    /// <summary>
    /// 评分
    /// </summary>
    public class Ratings
    {
        /// <summary>
        /// 用户给某个游戏评价多少分
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="gameid"></param>
        /// <param name="point"></param>
        public static void Games(string userid, string gameid, double point, DateTime ratingtime)
        {
            string tableName = "gameratings";
            using (var hclient = HBaseClientPool.GetHclient())
            {
                string strtime = H.Comm.TimeUtility.DescTimeStamp(ratingtime).ToString();
                string row = H.Comm.StringUtility.FixedLenString(userid, 20) + strtime;

                hclient.Client.mutateRow(tableName.ToBytes(), row.ToBytes(),
                    new List<Apache.Hadoop.Hbase.Mutation> { 
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:uid".ToBytes(), Value = userid.ToBytes() },
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:gid".ToBytes(), Value = gameid.ToBytes() },
                new Apache.Hadoop.Hbase.Mutation{ Column= "u:lt".ToBytes(), Value = ratingtime.ToString().ToBytes() },
                 new Apache.Hadoop.Hbase.Mutation{ Column= "u:pnt".ToBytes(), Value = point.ToString().ToBytes() }
                });
            }
        }


    }
}
