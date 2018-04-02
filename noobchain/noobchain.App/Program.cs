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
        public static List<Block> blockchain = new List<Block>();

        public static void Main(string[] args)
        {
            //add our blocks to the blockchain ArrayList:
            blockchain.Add(new Block("Hi im the first block", "0"));
            blockchain.Add(new Block("Yo im the second block", blockchain[blockchain.Count - 1].hash));
            blockchain.Add(new Block("Hey im the third block", blockchain[blockchain.Count - 1].hash));

            String blockchainJson = JsonConvert.SerializeObject(blockchain);

            Console.WriteLine(blockchainJson);
        }

        public static Boolean isChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            //loop through blockchain to check hashes:
            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain[i];
                previousBlock = blockchain[i - 1];

                //compare registered hash and calculated hash:
                if (!currentBlock.hash.Equals(currentBlock.calculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");

                    return false;
                }

                //compare previous hash and registered previous hash
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");

                    return false;
                }
            }

            return true;
        }
    }
}
