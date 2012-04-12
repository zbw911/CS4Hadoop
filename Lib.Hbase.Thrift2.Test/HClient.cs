using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

using Apache.Hadoop.Hbase;
using Apache.Hadoop.Hbase.Thrift2;

namespace Hbase.Test
{
    public class HClient
    {

        public static void FistTest()
        {


            Console.WriteLine("Thrift2 Demo");
            Console.WriteLine("This demo assumes you have a table called \"example\" with a column family called \"family1\"");

            String host = "hserver";
            int port = 9090;
            int timeout = 10000;
            var framed = false;

            TTransport transport = new TSocket(host, port, timeout);
            if (framed)
            {
                transport = new TFramedTransport(transport);
            }
            TProtocol protocol = new TBinaryProtocol(transport);
            // This is our thrift client.
            THBaseService.Iface client = new THBaseService.Client(protocol);

            // open the transport
            transport.Open();

            var table = "t1".ToBytes();

            TPut put = new TPut();
            put.Row = ("row1".ToBytes());

            for (var i = 0; i < 1000; i++)
            {

                TColumnValue columnValue = new TColumnValue();
                columnValue.Family = ("f1".ToBytes());
                columnValue.Qualifier = ("qualifier" + i).ToBytes();
                columnValue.Value = ("value" + i).ToBytes();
                List<TColumnValue> columnValues = new List<TColumnValue>();
                columnValues.Add(columnValue);
                put.ColumnValues = columnValues;

                client.put(table, put);
            }

            TGet get = new TGet();
            get.Row = ("row1".ToBytes());

            TResult result = client.get(table, get);

            Console.WriteLine("row = " + result.Row.ToStr());
            foreach (TColumnValue resultColumnValue in result.ColumnValues)
            {
                Console.WriteLine("family = " + resultColumnValue.Family.ToStr());
                Console.WriteLine("qualifier = " + resultColumnValue.Qualifier.ToStr());
                Console.WriteLine("value = " + resultColumnValue.Value.ToStr());
                Console.WriteLine("timestamp = " + resultColumnValue.Timestamp);
            }

            transport.Close();


        }


        public static void userFilter()
        {
            String host = "hserver";
            int port = 9090;
            int timeout = 10000;
            var framed = false;

            TTransport transport = new TSocket(host, port, timeout);
            if (framed)
            {
                transport = new TFramedTransport(transport);
            }
            TProtocol protocol = new TBinaryProtocol(transport);
            // This is our thrift client.
            THBaseService.Iface client = new THBaseService.Client(protocol);

            // open the transport
            transport.Open();





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
