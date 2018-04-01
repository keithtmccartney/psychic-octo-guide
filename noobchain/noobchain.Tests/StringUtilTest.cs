using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noobchain.Library;
using noobchain.Library.Helpers;

namespace noobchain.Tests
{
    [TestClass]
    public class StringUtilTest
    {
        String _data = "Hi im the first block";
        String _previousHash = "0";

        [TestMethod]
        public void StringUtilTestMethod()
        {
            StringUtil stringUtil = new StringUtil();
        }

        [TestMethod]
        public void StringUtilApplySha256TestMethod()
        {
            StringUtil.applySha256(_data);
        }
    }
}
