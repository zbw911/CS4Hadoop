using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Comm
{
    /// <summary>
    /// 关于时间的一些方法
    /// added by zbw911
    /// </summary>
    public class TimeUtility
    {
        //public static string DescTimeKey(DateTime datetime)
        //{
        //    var timespan = DateTime.MaxValue - datetime;

        //}

        /// <summary>
        /// java timestamp to datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime JavaTimeStampToDateTime(long timeStamp)
        {
            var timeStart = new DateTime(1970, 1, 1);
            //加8区
            timeStart = timeStart.AddHours(8);

            var ts = TimeSpan.FromTicks(timeStamp * 10000);
            var datetime = timeStart.Add(ts);
            return datetime;
        }

        /// <summary>
        /// 生成java版本的 timestamp
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long DateTimeToJavaTimeStamp(DateTime datetime)
        {
            var timeStart = new DateTime(1970, 1, 1);

            var ts = datetime - timeStart - new TimeSpan(8, 0, 0);

            return ts.Ticks / 10000;
        }

        /// <summary>
        /// 生成用于降序的key
        /// long.max = 9223372036854775807, 这个在java 运算过程中要注意的问题，还要，java的 long 与C# long的maxvalue是一样的
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long DescTimeStamp(DateTime datetime)
        {
            return long.MaxValue - DateTimeToJavaTimeStamp(datetime);
        }

        /// <summary>
        /// 降序stamp对应的值
        /// </summary>
        /// <param name="descstamp"></param>
        /// <returns></returns>
        public static DateTime DescTimeStampToTime(long descstamp)
        {
            var timeStamp = long.MaxValue - descstamp;
            var datetime = JavaTimeStampToDateTime(timeStamp);

            return datetime;
        }

        /// <summary>
        /// @test
        /// </summary>
        private static void t()
        {
            var ts = 1322721969001;

            var jst = JavaTimeStampToDateTime(ts);

            Console.WriteLine(jst.ToString());

            var ss = DateTimeToJavaTimeStamp(jst);

            if (ts != ss)
            {
                Console.WriteLine("!=");
            }
            else
            {
                Console.WriteLine("==");
            }
 
        }

    }
}
