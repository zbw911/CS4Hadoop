using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using Apache.Hadoop.Thriftfs.Api;

namespace Lib.HDFS.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            //var transport = new TBufferedTransport(new TSocket("hserver", 49393));


            //transport.Open();


            //var protocol = new TBinaryProtocol(transport);


            //var client = new ThriftHadoopFileSystem.Client(protocol);



            ////var handle = client.create(new Pathname { pathname = "/aaaa" });

            ////Console.WriteLine(handle);

            //var handler = client.open(new Pathname { pathname = "/user" });

            //var liststat = client.listStatus(new Pathname { pathname = "/user" });

            //foreach (var item in liststat)
            //{
            //    Console.WriteLine(item.Path);
            //}

            //transport.Close();



            test();

        }


        public static void test()
        {
            var hadoop_socket = new TSocket("hserver", 59256);
            hadoop_socket.Timeout = 10000;// Ten seconds

            //$hadoop_socket -> setRecvTimeout(20000); // Twenty seconds
            var hadoop_transport = new TBufferedTransport(hadoop_socket);
            var hadoop_protocol = new TBinaryProtocol(hadoop_transport);
            var hadoopClient = new ThriftHadoopFileSystem.Client(hadoop_protocol);
            hadoop_transport.Open();

            //if (hadoopClient.exists(new Pathname { pathname = "/user/root/input" }))
            //{
            //    System.Console.WriteLine("exists");
            //}
            //else
            //{
            //    Console.WriteLine("no exists");


            //}

            //hadoopClient.mkdirs(new Pathname { pathname = "/zbw911_user" });
            //hadoopClient.rm(new Pathname { pathname = "/zbw911_user" }, true);

            //var h = hadoopClient.createFile(new Pathname { pathname = "user_zbw911" }, 1, true, 1000, 1, 64000);


            var list = hadoopClient.listStatus(new Pathname { pathname = "/user/root" });

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
                //if (item.Isdir)
                //{
                //    System.Console.WriteLine("文件夹：" + item.Path + "；权限：" + item.Permission);
                //}
                //else
                //{

                //    System.Console.WriteLine("文件：" + item.Path + "；权限：" + item.Permission);

                //}
            }

            //hadoopClient.close(h);



            //hadoopClient.open(new Pathname { pathname = "/user/root" });

            hadoop_transport.Close();
        }


        /***
         
         <?php
	$GLOBALS['THRIFT_ROOT'] = ROOTPATH . '/lib/thrift';
	require_once($GLOBALS['THRIFT_ROOT'].'/Thrift.php');
	require_once($GLOBALS['THRIFT_ROOT'].'/transport/TSocket.php');
	require_once($GLOBALS['THRIFT_ROOT'].'/transport/TBufferedTransport.php');
	require_once($GLOBALS['THRIFT_ROOT'].'/protocol/TBinaryProtocol.php');
	require_once($GLOBALS["THRIFT_ROOT"] . "/packages/hadoopfs/ThriftHadoopFileSystem.php");
	$hadoop_socket = new TSocket("localhost", 59256);
	$hadoop_socket -> setSendTimeout(10000); // Ten seconds
	$hadoop_socket -> setRecvTimeout(20000); // Twenty seconds
	$hadoop_transport = new TBufferedTransport($hadoop_socket);
	$hadoop_protocol = new TBinaryProtocol($hadoop_transport);
	$hadoopClient = new ThriftHadoopFileSystemClient($hadoop_protocol);
	$hadoop_transport -> open();
	try {
		// create directory
		$dirpathname = new hadoopfs_Pathname(array("pathname" => "/user/root/hadoop"));
		if($hadoopClient -> exists($dirpathname) == TRUE) {
			echo $dirpathname -> pathname . " exists.\n";
		} else {
			$result = $hadoopClient -> mkdirs($dirpathname);
		}
		// put file
		$filepathname = new hadoopfs_Pathname(array("pathname" => $dirpathname -> pathname . "/hello.txt"));
		$localfile = fopen("hello.txt", "rb");
		$hdfsfile = $hadoopClient -> create($filepathname);
		while(true) {
			$data = fread($localfile, 1024);
			if(strlen($data) == 0)
				break;
			$hadoopClient -> write($hdfsfile, $data);
		}
		$hadoopClient -> close($hdfsfile);
		fclose($localfile);
		// get file
		echo "read file:\n";
		print_r($filepathname);
		$data = "";
		$hdfsfile = $hadoopClient -> open($filepathname);
		print_r($hdfsfile);
		while(true) {
			$data = $hadoopClient -> read($hdfsfile, 0, 1024);
			if(strlen($data) == 0)
				break;
			print $data;
		}
		$hadoopClient -> close($hdfsfile);
		echo "listStatus:\n";
		$result = $hadoopClient -> listStatus($dirpathname);
		print_r($result);
		foreach($result as $key => $value) {
			if($value -> isdir == "1")
				print "dir\t";
			else
				print "file\t";
			print $value -> block_replication . "\t" . $value -> length . "\t" . $value -> modification_time . "\t" . $value -> permission . "\t" . $value -> owner . "\t" . $value -> group . "\t" . $value -> path . "\n";
		}
		$hadoop_transport -> close();
	} catch(Exception $e) {
		print_r($e);
	}
?>

         **/

    }
}
