using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;
using System.Threading;

namespace H.HbaseProvider
{
    /// <summary>
    /// Hbaseclient 
    /// added by zbw911
    /// </summary>
    public class HClient : IDisposable
    {
        private static string host = System.Configuration.ConfigurationManager.AppSettings["hbasehost"];
        private static int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["hbaseport"]);

        public bool IsFree;
        public Apache.Hadoop.Hbase.Hbase.Client Client;

        private TSocket socket;
        private TProtocol protocol;
        private TTransport Transport;
        public HClient()
        {
            socket = new TSocket(host, port);
            this.Transport = new TBufferedTransport(socket);
            //Transport.Open();
            this.protocol = new TBinaryProtocol(Transport);
            this.Client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            this.IsFree = true;
        }

        public bool IsOpen
        {
            get
            {
                return this.Transport.IsOpen;
            }
        }

        public void Open()
        {
            this.Transport.Open();
        }

        public void Close()
        {
            this.Transport.Close();
        }

        public void Dispose()
        {
            IsFree = true;
        }
    }

    /// <summary>
    /// Hbase 连接池
    /// added by zbw911
    /// </summary>
    public class HBaseClientPool
    {
        private static int DEFAULT_COUNT = 10;
        private static int MAX_CLIENTCOUNT = 20;
        private static List<HClient> clientlist = null;


        private static Mutex m_mutex = new Mutex();


        static HBaseClientPool()
        {
            clientlist = new List<HClient>(DEFAULT_COUNT);

            for (var i = 0; i < DEFAULT_COUNT; i++)
                clientlist.Add(new HClient());

        }



        /// <summary>
        /// 从连接池中取出一个可用连接对象
        /// </summary>
        /// <returns></returns> cf c
        public static HClient GetHclient()
        {
            m_mutex.WaitOne(); //先阻塞
            for (var i = 0; i < clientlist.Count; i++)
            {
                if (clientlist[i].IsFree)
                {
                   
                    clientlist[i].IsFree = false;
                    m_mutex.ReleaseMutex();//释放资源
                    return clientlist[i];
                }
            }

              

            if (clientlist.Count > MAX_CLIENTCOUNT) throw new Exception("超出最大HClinet最大个数");

            var item = new HClient();

            item.Open();
            item.IsFree = false;
            m_mutex.ReleaseMutex();//释放资源
            return item;
        }

       
    }
}
