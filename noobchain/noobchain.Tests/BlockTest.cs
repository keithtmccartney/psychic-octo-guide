using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using noobchain.Library;

namespace noobchain.Tests
{
    [TestClass]
    public class BlockTest
    {
        public static List<Block> blockchain = new List<Block>();
        public static int difficulty = 5;

        String _data = "Hi im the first block";
        String _previousHash = "0";

        [TestMethod]
        public void BlockTestMethod()
        {
            Block block = new Block(_data, _previousHash);
        }

        [TestMethod]
        public void BlockCalculateHashTestMethod()
        {
            Block block = new Block(_data, _previousHash);

            block.calculateHash();
        }

        /// <summary>
        /// Each block now has its own digital signature based on its information and the signature of the previous block;
        /// </summary>
        [TestMethod]
        public void BlockHashTestMethod()
        {
            Block genesisBlock = new Block("Hi im the first block", "0");
            Console.WriteLine("Hash for block 1 : " + genesisBlock.hash);

            Block secondBlock = new Block("Yo im the second block", genesisBlock.hash);
            Console.WriteLine("Hash for block 2 : " + secondBlock.hash);

            Block thirdBlock = new Block("Hey im the third block", secondBlock.hash);
            Console.WriteLine("Hash for block 3 : " + thirdBlock.hash);
        }

        [TestMethod]
        public void BlockchainTestMethod()
        {
            //add our blocks to the blockchain ArrayList:
            blockchain.Add(new Block("Hi im the first block", "0"));
            blockchain.Add(new Block("Yo im the second block", blockchain[blockchain.Count - 1].hash));
            blockchain.Add(new Block("Hey im the third block", blockchain[blockchain.Count - 1].hash));

            String blockchainJson = JsonConvert.SerializeObject(blockchain);

            Console.WriteLine(blockchainJson);
        }

        [TestMethod]
        public void BlockchainValidityTestMethod()
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

                    /*return false;*/
                }

                //compare previous hash and registered previous hash
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");

                    /*return false;*/
                }
            }

            /*return true;*/
        }

        [TestMethod]
        public void MineBlockTestMethod()
        {
            Block block = new Block(_data, _previousHash);

            block.mineBlock(difficulty);
        }
    }
}
