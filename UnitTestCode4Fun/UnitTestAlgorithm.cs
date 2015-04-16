using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code4Fun;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestCode4Fun
{
    struct Messages
    {
        public const string Record_Excluded = "Record excluded from calculation";
        public const string Test_Failed = "Test failed";
        public const string Test_Succeded = "Test succeded";
        public const string Average_Failed = "Average latency calculated incorrectly";
        public const string Total_Failed = "Total bandwidth calculated incorrectly";
    }

    struct TSVData
    {
        public string file_name;
        public int num_connections;
        public int latency_ms;
        public int bandwidth;
    }

    [TestClass]
    public class UnitTestAlgorithm
    {
        List<TSVData> data = new List<TSVData>();

        public UnitTestAlgorithm()
        {
            //creating input data (random)
            Random r = new Random();

            int n = r.Next(1, 10000);

            while (n > 0)
            {
                TSVData item = new TSVData()
                {
                    file_name = n.ToString(),
                    num_connections = r.Next(1, 10000),
                    latency_ms = r.Next(1, 10000),
                    bandwidth = r.Next(1, 10000)
                };

                data.Add(item);

                n--;
            }
        }

        [TestMethod]
        public void TestCallMethod()
        {
            //simple call
            double latency = 0, bandwidth = 0;

            Algorithm a = new Algorithm();

            a.Statistics(ref latency, ref bandwidth, 0, 0);
        }

        [TestMethod]
        public void TestMultipleCalls()
        {
            //simulate multiple calls with random positive values
            double averageLatency = 0, totalBandwidth = 0;

            //expected values
            double averageLatencyEx = 0, totalBandwidthEx = 0;

            averageLatencyEx = data.Where(x => x.latency_ms > 0).Average(x => x.latency_ms);
            totalBandwidthEx = data.Where(x => x.bandwidth > 0).Sum(x => x.bandwidth);

            //calculeted values with method
            Algorithm a = new Algorithm();

            foreach (TSVData item in data)
            {
                if (a.Statistics(ref averageLatency, ref totalBandwidth, item.latency_ms, item.bandwidth))
                {
                }
                else
                {
                    Assert.Fail(Messages.Record_Excluded);
                }
            }

            Assert.AreNotEqual(averageLatency, averageLatencyEx, Messages.Average_Failed);
            Assert.AreNotEqual(totalBandwidth, totalBandwidth, Messages.Total_Failed);
        }
    }
}
