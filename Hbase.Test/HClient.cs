using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

using Apache.Hadoop.Hbase;

namespace Hbase.Test
{
    public class HClient
    {

        public static void AddColumn()
        {


            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);


            //client.createTable(Unitl.StrToBytes("t"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("default"), InMemory = false } });
            //client.createTable(Unitl.StrToBytes("thetable"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("default"), InMemory = false } });

            for (var i = 0; i < 10; i++)
            {



                client.mutateRow(Unitl.StrToBytes("t"),

                    Unitl.StrToBytes("key"),
                    new List<Mutation> { 
                        new Mutation { Column = Unitl.StrToBytes("default:"+i ), Value = Unitl.StrToBytes( System.DateTime.Now.ToString() ) }
                    
                    });




            }
            transport.Close();


        }



        public static void addALotCol()
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);


            //client.createTable(Unitl.StrToBytes("t"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("default"), InMemory = false } });
            //client.createTable(Unitl.StrToBytes("thetable"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("default"), InMemory = false } });

            for (var i = 0; i < 1000000; i++)
            {

                client.mutateRow(Unitl.StrToBytes("t1"),

                    Unitl.StrToBytes("rowno"),
                    new List<Mutation> { 
                        new Mutation { Column = Unitl.StrToBytes("f1:"+i ), Value = Unitl.StrToBytes( System.DateTime.Now.ToString() ) }
                    
                    });
            }
            for (var i = 0; i < 10; i++)
            {

                client.mutateRow(Unitl.StrToBytes("t1"),

                    Unitl.StrToBytes("rowno"),
                    new List<Mutation> { 
                        new Mutation { Column = Unitl.StrToBytes("f2:"+i ), Value = Unitl.StrToBytes( System.DateTime.Now.ToString() ) }
                    
                    });
            }
            for (var i = 0; i < 10; i++)
            {

                client.mutateRow(Unitl.StrToBytes("t1"),

                    Unitl.StrToBytes("rowno"),
                    new List<Mutation> { 
                        new Mutation { Column = Unitl.StrToBytes("f3:"+i ), Value = Unitl.StrToBytes( System.DateTime.Now.ToString() ) }
                    
                    });



            }




            transport.Close();
        }


        public static void Scan()
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            var scanid = client.scannerOpenWithStop(Unitl.StrToBytes("t1"), Unitl.StrToBytes("rowno"), Unitl.StrToBytes("rowno"),
                new List<byte[]> { Unitl.StrToBytes("f1:99913") });

            var result = client.scannerGet(scanid);

            var colum = client.getColumnDescriptors("t1".ToBytes());

            var rows = client.getRowsWithColumns("t1".ToBytes()
                  , new List<byte[]> { "rowno".ToBytes() }
                  , new List<byte[]> { "f1:9".ToBytes(), "f1:9999".ToBytes() });

            
            //scanid = client.scannerOpenWithPrefix("".ToBytes(), "".ToBytes(), new List<byte[]> { });

            var v = client.getVer("table".ToBytes(), "row".ToBytes(), "col".ToBytes(), 1000);

            foreach (var xx in v)
            {
                
            }

           

            foreach (var r in result)
            {
                Console.WriteLine(r.Columns[Unitl.StrToBytes("f1:99913")].Value);
            }

            client.scannerClose(scanid);

            transport.Close();
        }




        public static void ShowTables()
        {

            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            var tables = client.getTableNames();

            foreach (var table in tables)
            {
                Console.WriteLine(Unitl.BytesToStr(table));
            }

            transport.Close();

        }

        public static void GetData()
        {

            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            var rows = client.getRow(Unitl.StrToBytes("1"), Unitl.StrToBytes("row9916"));

            foreach (var row in rows)
            {
                Console.WriteLine(row.Columns.ToString());
            }

            transport.Close();
        }

        public static void AddTable(string tablename)
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);



            client.createTable(Unitl.StrToBytes(tablename), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("zbw911"), InMemory = false } });




            transport.Close();
        }


        public static void AddData()
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            //client.createTable(Unitl.StrToBytes(tablename), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("zbw911"), InMemory = false } });

            client.mutateRow(Unitl.StrToBytes("1"), Unitl.StrToBytes("key"), new List<Mutation> { new Mutation { Column = Unitl.StrToBytes("zbw911"), Value = Unitl.StrToBytes("zbw911") } });



            transport.Close();
        }


        public static void UpdateData()
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            //client.createTable(Unitl.StrToBytes(tablename), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("zbw911"), InMemory = false } });

            client.mutateRow(Unitl.StrToBytes("1"), Unitl.StrToBytes("key"), new List<Mutation> { new Mutation { Column = Unitl.StrToBytes("zbw911"), Value = Unitl.StrToBytes("zbw911-Modifyed") } });



            transport.Close();
        }

        public static void AddData(string row)
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);


            //client.createTable(Unitl.StrToBytes(tablename), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("zbw911"), InMemory = false } });

            client.mutateRow(Unitl.StrToBytes("1"), Unitl.StrToBytes(row), new List<Mutation> { new Mutation { Column = Unitl.StrToBytes("zbw911"), Value = Unitl.StrToBytes("zbw911") } });

            transport.Close();
        }





        public static void BatAddData()
        {
            var transport = new TBufferedTransport(new TSocket("master", 9090));


            transport.Open();


            var protocol = new TBinaryProtocol(transport);

            var client = new Apache.Hadoop.Hbase.Hbase.Client(protocol);

            //client.createTable(Unitl.StrToBytes(tablename), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Unitl.StrToBytes("zbw911"), InMemory = false } });

            var bytevalue = Unitl.StrToBytes(Longdata);

            for (var j = 0; j < 100000; j++)
            {
                //var j = 0;
                for (var i = 0; i < 1000; i++)
                {
                    client.mutateRow(Unitl.StrToBytes("1"), Unitl.StrToBytes("" + i + "___" + j), new List<Mutation> { new Mutation { Column = Unitl.StrToBytes("zbw911"), Value = bytevalue } });
                }

                Console.WriteLine(j + "批=" + 1000 * j);
            }


            transport.Close();
        }




        static string Longdata = "1";


        static string data = @"
Region Server: slave3:60020
 
Local logs, Thread Dump, Log Level
 
--------------------------------------------------------------------------------

Region Server Attributes
 


Attribute Name

Value

Description

 

HBase Version

0.90.4, r1150278

HBase version and svn revision

 

HBase Compiled

Sun Jul 24 15:53:29 PDT 2011, stack

When HBase version was compiled and by whom

 

Metrics

requests=715, regions=5, stores=5, storefiles=0, storefileIndexSize=0, memstoreSize=6, compactionQueueSize=0, flushQueueSize=0, usedHeap=38, maxHeap=998, blockCacheSize=982416, blockCacheFree=208405104, blockCacheCount=0, blockCacheHitCount=0, blockCacheMissCount=0, blockCacheEvictedCount=0, blockCacheHitRatio=0, blockCacheHitCachingRatio=0

RegionServer Metrics; file and heap sizes are in megabytes

 

Zookeeper Quorum

slave3:2181,slave2:2181,slave1:2181

Addresses of all registered ZK servers

 
Online Regions
 


Region Name

Start Key

End Key

Metrics



.META.,,1.1028785192



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



1,,1320128401145.4e3ba0c4eb2910c3079f66c1b2d43163.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=6, storefileIndexSizeMB=0



4,,1320128405272.c2b8f417e2b3333ab243f33946b04fdc.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



7,,1320128409368.5fb7097115a33f756c8b0585d60825c5.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



8,,1320128410855.a16a63ca5a2f4722c1fd01c7c3fee9cd.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0

 
Region names are made of the containing table's name, a comma, the start key, a comma, and a randomly generated region id. To illustrate, the region named domains,apache.org,5464829424211263407 is party to the table domains, has an id of 5464829424211263407 and the first key in the region is apache.org. The -ROOT- and .META. 'tables' are internal sytem tables (or 'catalog' tables in db-speak). The -ROOT- keeps a list of all regions in the .META. table. The .META. table keeps a list of all regions in the system. The empty key is used to denote table start and table end. A region with an empty start key is the first region in a table. If region has both an empty start and an empty end key, its the only region in the table. See HBase Home for further explication.

Region Server: slave3:60020
 
Local logs, Thread Dump, Log Level
 
--------------------------------------------------------------------------------

Region Server Attributes
 


Attribute Name

Value

Description

 

HBase Version

0.90.4, r1150278

HBase version and svn revision

 

HBase Compiled

Sun Jul 24 15:53:29 PDT 2011, stack

When HBase version was compiled and by whom

 

Metrics

requests=715, regions=5, stores=5, storefiles=0, storefileIndexSize=0, memstoreSize=6, compactionQueueSize=0, flushQueueSize=0, usedHeap=38, maxHeap=998, blockCacheSize=982416, blockCacheFree=208405104, blockCacheCount=0, blockCacheHitCount=0, blockCacheMissCount=0, blockCacheEvictedCount=0, blockCacheHitRatio=0, blockCacheHitCachingRatio=0

RegionServer Metrics; file and heap sizes are in megabytes

 

Zookeeper Quorum

slave3:2181,slave2:2181,slave1:2181

Addresses of all registered ZK servers

 
Online Regions
 


Region Name

Start Key

End Key

Metrics



.META.,,1.1028785192



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



1,,1320128401145.4e3ba0c4eb2910c3079f66c1b2d43163.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=6, storefileIndexSizeMB=0



4,,1320128405272.c2b8f417e2b3333ab243f33946b04fdc.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



7,,1320128409368.5fb7097115a33f756c8b0585d60825c5.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



8,,1320128410855.a16a63ca5a2f4722c1fd01c7c3fee9cd.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0

 
Region names are made of the containing table's name, a comma, the start key, a comma, and a randomly generated region id. To illustrate, the region named domains,apache.org,5464829424211263407 is party to the table domains, has an id of 5464829424211263407 and the first key in the region is apache.org. The -ROOT- and .META. 'tables' are internal sytem tables (or 'catalog' tables in db-speak). The -ROOT- keeps a list of all regions in the .META. table. The .META. table keeps a list of all regions in the system. The empty key is used to denote table start and table end. A region with an empty start key is the first region in a table. If region has both an empty start and an empty end key, its the only region in the table. See HBase Home for further explication.

Region Server: slave3:60020
 
Local logs, Thread Dump, Log Level
 
--------------------------------------------------------------------------------

Region Server Attributes
 


Attribute Name

Value

Description

 

HBase Version

0.90.4, r1150278

HBase version and svn revision

 

HBase Compiled

Sun Jul 24 15:53:29 PDT 2011, stack

When HBase version was compiled and by whom

 

Metrics

requests=715, regions=5, stores=5, storefiles=0, storefileIndexSize=0, memstoreSize=6, compactionQueueSize=0, flushQueueSize=0, usedHeap=38, maxHeap=998, blockCacheSize=982416, blockCacheFree=208405104, blockCacheCount=0, blockCacheHitCount=0, blockCacheMissCount=0, blockCacheEvictedCount=0, blockCacheHitRatio=0, blockCacheHitCachingRatio=0

RegionServer Metrics; file and heap sizes are in megabytes

 

Zookeeper Quorum

slave3:2181,slave2:2181,slave1:2181

Addresses of all registered ZK servers

 
Online Regions
 


Region Name

Start Key

End Key

Metrics



.META.,,1.1028785192



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



1,,1320128401145.4e3ba0c4eb2910c3079f66c1b2d43163.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=6, storefileIndexSizeMB=0



4,,1320128405272.c2b8f417e2b3333ab243f33946b04fdc.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



7,,1320128409368.5fb7097115a33f756c8b0585d60825c5.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



8,,1320128410855.a16a63ca5a2f4722c1fd01c7c3fee9cd.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0

 
Region names are made of the containing table's name, a comma, the start key, a comma, and a randomly generated region id. To illustrate, the region named domains,apache.org,5464829424211263407 is party to the table domains, has an id of 5464829424211263407 and the first key in the region is apache.org. The -ROOT- and .META. 'tables' are internal sytem tables (or 'catalog' tables in db-speak). The -ROOT- keeps a list of all regions in the .META. table. The .META. table keeps a list of all regions in the system. The empty key is used to denote table start and table end. A region with an empty start key is the first region in a table. If region has both an empty start and an empty end key, its the only region in the table. See HBase Home for further explication.

Region Server: slave3:60020
 
Local logs, Thread Dump, Log Level
 
--------------------------------------------------------------------------------

Region Server Attributes
 


Attribute Name

Value

Description

 

HBase Version

0.90.4, r1150278

HBase version and svn revision

 

HBase Compiled

Sun Jul 24 15:53:29 PDT 2011, stack

When HBase version was compiled and by whom

 

Metrics

requests=715, regions=5, stores=5, storefiles=0, storefileIndexSize=0, memstoreSize=6, compactionQueueSize=0, flushQueueSize=0, usedHeap=38, maxHeap=998, blockCacheSize=982416, blockCacheFree=208405104, blockCacheCount=0, blockCacheHitCount=0, blockCacheMissCount=0, blockCacheEvictedCount=0, blockCacheHitRatio=0, blockCacheHitCachingRatio=0

RegionServer Metrics; file and heap sizes are in megabytes

 

Zookeeper Quorum

slave3:2181,slave2:2181,slave1:2181

Addresses of all registered ZK servers

 
Online Regions
 


Region Name

Start Key

End Key

Metrics



.META.,,1.1028785192



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



1,,1320128401145.4e3ba0c4eb2910c3079f66c1b2d43163.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=6, storefileIndexSizeMB=0



4,,1320128405272.c2b8f417e2b3333ab243f33946b04fdc.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



7,,1320128409368.5fb7097115a33f756c8b0585d60825c5.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0



8,,1320128410855.a16a63ca5a2f4722c1fd01c7c3fee9cd.



stores=1, storefiles=0, storefileSizeMB=0, memstoreSizeMB=0, storefileIndexSizeMB=0

 
Region names are made of the containing table's name, a comma, the start key, a comma, and a randomly generated region id. To illustrate, the region named domains,apache.org,5464829424211263407 is party to the table domains, has an id of 5464829424211263407 and the first key in the region is apache.org. The -ROOT- and .META. 'tables' are internal sytem tables (or 'catalog' tables in db-speak). The -ROOT- keeps a list of all regions in the .META. table. The .META. table keeps a list of all regions in the system. The empty key is used to denote table start and table end. A region with an empty start key is the first region in a table. If region has both an empty start and an empty end key, its the only region in the table. See HBase Home for further explication.


";


    }
}
