using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using noobchain.Library;

namespace noobchain.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Block> blockchain = new List<Block>();

            //add our blocks to the blockchain ArrayList:
            blockchain.Add(new Block("Hi im the first block", "0"));
            blockchain.Add(new Block("Yo im the second block", blockchain[blockchain.Count - 1].hash));
            blockchain.Add(new Block("Hey im the third block", blockchain[blockchain.Count - 1].hash));

            String blockchainJson = JsonConvert.SerializeObject(blockchain);

            Console.WriteLine(blockchainJson);
        }
    }
}
