using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noobchain.Library;

namespace noobchain.Tests
{
    [TestClass]
    public class BlockTest
    {
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
    }
}
