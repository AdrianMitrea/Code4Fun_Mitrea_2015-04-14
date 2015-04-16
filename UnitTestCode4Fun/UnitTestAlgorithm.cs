using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code4Fun;

namespace UnitTestCode4Fun
{
    struct data
    {
        int num_connections;
        int latency_ms;
        int bandwidth;
    }

    [TestClass]
    public class UnitTestAlgorithm
    {
        public UnitTestAlgorithm()
        {
            //creating input data (random)

        }

        [TestMethod]
        public void TestCallMethod()
        {
            double latency = 0, bandwidth = 0;
            
            Algorithm a = new Algorithm();

            a.Statistics(ref latency, ref bandwidth);
        }
    }
}
