using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noobchain.Library;
using noobchain.Library.Helpers;

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
    }
}
