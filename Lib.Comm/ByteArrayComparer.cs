using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Comm
{

    /// <summary>
    /// <seealso cref="http://stackoverflow.com/questions/1440392/use-byte-as-key-in-dictionary"/> 
    /// <seealso cref="http://www.cnblogs.com/zbw911/archive/2011/12/01/2270841.html"/> 
    /// added by zbw911
    /// <example>
    /// <![CDATA[
    ///  Dictionary<byte[], string> dic = new Dictionary<byte[], string>(new ByteArrayComparer());
    ///        dic.Add("key".ToBytes(), "zbbb");
    ///       Console.WriteLine(dic["key".ToBytes()]);
    /// ]]>
    /// </example>
    /// </summary>
    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }
            if (left.Length != right.Length)
            {
                return false;
            }
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            int sum = 0;
            foreach (byte cur in key)
            {
                sum += cur;
            }
            return sum;
        }
    }
}
