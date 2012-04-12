using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.Comm;
namespace H.Example
{




    //public class ByteArrayComparer : IEqualityComparer<byte[]>
    //{
    //    public bool Equals(byte[] left, byte[] right)
    //    {
    //        if (left == null || right == null)
    //        {
    //            return left == right;
    //        }
    //        return left.Equals(right);
    //        //return left.SequenceEquals(right);
    //    }
    //    public int GetHashCode(byte[] key)
    //    {
    //        if (key == null)
    //            throw new ArgumentNullException("key");

    //      return  key.GetHashCode();
    //        //return key.Sum();
    //    }
    //} 



    class Program
    {

        /// <summary>
        /// 计算Php格式的当前时间
        /// </summary>
        /// <returns>Php格式的时间</returns>
        public static long PhpTimeNow()
        {
            return DateTimeToPhpTime(DateTime.UtcNow);
        }

        /// <summary>
        /// PhpTime转DataTime
        /// </summary>
        /// <returns></returns>
        public static DateTime PhpTimeToDateTime(long time)
        {
            var timeStamp = new DateTime(1970, 1, 1);
            var t = (time + 8 * 60 * 60) * 10000000 + timeStamp.Ticks;
            return new DateTime(t);
        }

        /// <summary>
        /// DataTime转PhpTime
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        public static long DateTimeToPhpTime(DateTime datetime)
        {
            var timeStamp = new DateTime(1970, 1, 1);
            return (datetime.Ticks - timeStamp.Ticks) / 10000000;
        }


        public static void testc()
        {

            var timeStamp = new DateTime(1970, 1, 1);
            timeStamp.AddHours(8);
            var ts = TimeSpan.FromMilliseconds(1322722118180);



            var t = timeStamp.Add(ts);

            Console.WriteLine(t.ToString());

            Console.WriteLine(PhpTimeToDateTime(1322722118180 / 1000).ToString());
        }

        static void Main(string[] args)
        {
            Useage();
            var key = "";
            while ((key = Console.ReadLine()) != "q")
            {

                switch (key)
                {
                    case "h":
                        Useage();
                        break;

                    case "1":
                        addlog();
                        break;

                    case "2":
                        batAddlog();
                        break;

                    case "3":
                        ShowLog();
                        break;

                    case "4":
                        InsertRunOn();
                        break;

                    //case "41":
                    //    PoolInsertRunOn();
                    //    break;

                    case "5":
                        scanIpStat();
                        break;


                    case "6":
                        addOrder();
                        break;


                    default:
                        Useage();
                        break;
                }
            }



        }

        static void Useage()
        {
            Console.WriteLine("h:help , q:quit");
            Console.WriteLine("1:addlog()");
            Console.WriteLine("2: batAddlog()");
            Console.WriteLine("3: ShowLog()");
            Console.WriteLine("4: InsertRunOn()");
            Console.WriteLine("41: PoolInsertRunOn()");
            Console.WriteLine("5: scanIpStat()");
            Console.WriteLine("================");
            Console.WriteLine("6:addOrder()");
        }

        static void addOrder()
        {
            int uid = 1000000;

            for (var i = 0; i < 100; i++)
            {
                string struid = (uid + i).ToString();
                string ip = "192.168.1." + (int)(i % 255);
                System.DateTime dt = System.DateTime.Now;

                if (i % 10 == 0)
                    Console.WriteLine(i);

                H.BLL.UserOrder.AddUserOrder(struid, "orderid" + uid, "proid" + ip, ip, 1, 10, 10, dt);
            }
        }

        #region Order
        static void addlog()
        {
            string uid = "1000000";
            string ip = "192.168.1.1";
            System.DateTime dt = System.DateTime.Now;


            H.BLL.LoginLog.AddLog(uid, ip, dt, true);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        static void batAddlog()
        {
            int uid = 1000000;

            for (var i = 0; i < 10000; i++)
            {
                string struid = (uid + i).ToString();
                string ip = "192.168.1." + (int)(i % 255);
                System.DateTime dt = System.DateTime.Now;

                if (i % 100 == 0)
                    Console.WriteLine(i);

                H.BLL.LoginLog.AddLog(struid, ip, dt, true);
            }
        }

        static void ShowLog()
        {
            var v = H.BLL.LoginLog.GetLog("1000000", 5);

            foreach (var item in v)
            {
                //最直接的方法
                Console.WriteLine(item.Row.ToStr() + "=>" + item.Columns["u:ip".ToBytes()].Value.ToStr());


                Console.WriteLine(item.Row.ToStr());
                //方法2
                foreach (var col in item.Columns)
                {
                    Console.WriteLine(col.Key.ToStr() + "=>" + col.Value.Value.ToStr());
                }

                Console.WriteLine("==========================");
            }
        }

        //不断的进行插入操作，看插入到什么情况下会出现问题
        // 已知情况，10亿数据未出问题
        static void InsertRunOn()
        {
            int uid = 1000000;

            for (var i = 0; true; i++)
            {
                string struid = (uid + i).ToString();
                string ip = "192.168.1." + (int)(i % 255);
                System.DateTime dt = System.DateTime.Now;

                if (i % 100 == 0)
                    Console.WriteLine(i);

                H.BLL.LoginLog.AddLog(struid, ip, dt, true);
            }
        }

        ////不断的进行插入操作，看插入到什么情况下会出现问题
        //// 已知情况，10亿数据未出问题
        //static void PoolInsertRunOn()
        //{
        //    int uid = 1000000;

        //    for (var i = 0; true; i++)
        //    {
        //        string struid = (uid + i).ToString();
        //        string ip = "192.168.1." + (int)(i % 255);
        //        System.DateTime dt = System.DateTime.Now;

        //        if (i % 100 == 0)
        //            Console.WriteLine(i);

        //        H.BLL.LoginLog.PoolAddLog(struid, ip, dt, true);
        //    }
        //}


        static void scanIpStat()
        {
            var v = H.BLL.LoginLog.ScanIp();

            foreach (var item in v)
            {
                //最直接的方法
                Console.WriteLine(item.Row.ToStr() + "=>" + item.Columns["r:c".ToBytes()].Value.ToStr());


                Console.WriteLine("==========================");
            }
        }

        #endregion

        //static void echo()
        //{
        //    for (var i = 0; i < 1000; i++)
        //    {
        //        string ip = "192.168.1." + (int)(i % 255);
        //        Console.WriteLine(ip);
        //    }
        //}
    }
}
