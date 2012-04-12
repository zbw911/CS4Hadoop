using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hbase.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (var i = 0; i < 10; i++)
            //    HClient.AddTable(i.ToString());

            //for (var j = 0; j < 100000; j++)
            //{
            //    //var j = 0;
            //    for (var i = 0; i < 1000; i++)
            //        HClient.AddData("row" + i + "_" + j);

            //    Console.WriteLine(j + "批");
            //}
            //HClient.ShowTables();

            //HClient.BatAddData();

            //HClient.GetData();


            //HClient.addALotCol();

            HClient.Scan();
        }



    }
}
