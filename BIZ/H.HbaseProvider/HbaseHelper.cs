using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;

namespace H.HbaseProvider
{
    /// <summary>
    /// hbase 帮助方法
    /// added by zbw911
    /// </summary>
    //public class HbaseHelper
    //{
    //    string host = "master";
    //    int port = 9090;
    //    static TBufferedTransport transport = null;
    //    public static Apache.Hadoop.Hbase.Hbase.Client GetConnection()
    //    {

    //        var socket = new TSocket("master", 9090);

    //        transport = new TBufferedTransport(socket);
    //        transport.Open();


    //        var protocol = new TBinaryProtocol(transport);

    //        var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

    //        return client;

    //    }


    //    public static void CloseConnection()
    //    {
    //        transport.Close();
    //    }
    //}
}
