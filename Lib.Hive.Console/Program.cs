using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.Hadoop.Hive;
using Thrift.Transport;
using Thrift.Protocol;

namespace Lib.Hive.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            t2();
        }
        public static void query()
        {
            var transport = new TBufferedTransport(new TSocket("hserver", 10000));
            var protocol = new TBinaryProtocol(transport);
            var client = new ThriftHive.Client(protocol);

            transport.Open();

            //client.execute("CREATE TABLE r(a STRING, b INT, c DOUBLE)");
            //client.execute("LOAD TABLE LOCAL INPATH '/path' INTO TABLE r");
            client.execute("SELECT * FROM pokes where foo=180");
            while (true)
            {
                var row = client.fetchOne();
                if (string.IsNullOrEmpty(row))
                    break;
                System.Console.WriteLine(row);
            }
            client.execute("SELECT * FROM pokes");
            var all = client.fetchAll();

            System.Console.WriteLine(all);

            transport.Close();
        }


        public static void t()
        {
            var transport = new TBufferedTransport(new TSocket("hserver", 10000));
            var protocol = new TBinaryProtocol(transport);
            var client = new ThriftHive.Client(protocol);

            transport.Open();

            //client.execute("CREATE TABLE r(a STRING, b INT, c DOUBLE)");
            //client.execute("LOAD TABLE LOCAL INPATH '/path' INTO TABLE r");

            var database = new Database();

            database.Name = "helloworldDB";
            database.Description = "测试用的第一个DB";

            client.create_database(database);

            transport.Close();
        }

        public static void t2()
        {
            var transport = new TBufferedTransport(new TSocket("hserver", 10000));
            var protocol = new TBinaryProtocol(transport);
            var client = new ThriftHive.Client(protocol);

            transport.Open();


            var database = new Database();

            database.Name = "helloworldDB";
            database.Description = "测试用的第一个DB";

            var tables = client.get_all_tables("default");

            //var tables = client.get_all_databases();

            foreach (var table in tables)
            {
                System.Console.WriteLine(table);
            }




            transport.Close();
        }
    }
}
