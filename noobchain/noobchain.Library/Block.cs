using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noobchain.Library.Helpers;

namespace noobchain.Library
{
    public class Block
    {
        public String hash; //hold digital signature;
        public String previousHash; //hold the previous block's hash;
        private String data; //hold block data; our data will be a simple message;
        private long timeStamp; //as number of milliseconds since 1/1/1970;

        //Block Constructor.
        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            this.timeStamp = CSharpMillisToJavaLong(DateTime.UtcNow);
            this.hash = calculateHash(); //Making sure we do this after we set the other values.
        }

        /// <summary>
        /// Java Date long to C# Datetime Millis: http://www.neetpiq.com/2013/12/16/java-date-long-to-cs-datetime-millis/;
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        static long CSharpMillisToJavaLong(DateTime dateTime)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            long diff = (long)(dateTime.ToUniversalTime() - Jan1st1970).TotalMilliseconds;

            return diff / 1000;
        }

        public String calculateHash()
        {
            String calculatedhash = StringUtil.applySha256(previousHash + Convert.ToString(timeStamp) + data);

            return calculatedhash;
        }
    }
}
