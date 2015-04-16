using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code4Fun;

namespace UnitTestCode4Fun
{
    [TestClass]
    public class UnitTestAlgorithm
    {
        [TestMethod]
        public void TestMethod1()
        {
            double latency = 0, bandwidth = 0;
            
            Algorithm a = new Algorithm();

            a.Statistics(ref latency, ref bandwidth);
        }
    }
}
