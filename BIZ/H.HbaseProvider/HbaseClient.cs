//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Thrift.Transport;
//using Thrift.Protocol;
//using Apache.Hadoop.Hbase;

//namespace H.HbaseProvider
//{
//    /// <summary>
//    /// 对Hbase Client 进行的一个包装
//    /// added by zbw911
//    /// </summary>
    
//    public class HbaseClient : IDisposable
//    {
//        public Apache.Hadoop.Hbase.Hbase.Client Client { get; private set; }

//        protected TBufferedTransport Transport { get; private set; }

//        private TSocket socket;
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="host"></param>
//        /// <param name="prot"></param>
//        public HbaseClient(string host, int prot)
//        {
//            socket = new TSocket(host, prot);

//            this.Transport = new TBufferedTransport(socket);
//            this.Transport.Open();    


//            var protocol = new TBinaryProtocol(Transport);
            

//            Client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);
         
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public HbaseClient()
//            : this(System.Configuration.ConfigurationManager.AppSettings["hbasehost"],
//            int.Parse(System.Configuration.ConfigurationManager.AppSettings["hbaseport"])
//            )
//        {

//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void Dispose()
//        {
//            this.socket.Close();
//            this.Transport.Close();

//        }
//    }
//}
