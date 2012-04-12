using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.HbaseProvider;
using H.Comm;

namespace H.BLL
{
    /// <summary>
    /// 内容相关
    /// 用户所产生的内容，用于数据挖掘
    /// </summary>
    public class Content
    {
        public void v()
        {

            string tableName = "tracku";

            using (var hclient = HBaseClientPool.GetHclient())
            {

            }
        }
    }
}
