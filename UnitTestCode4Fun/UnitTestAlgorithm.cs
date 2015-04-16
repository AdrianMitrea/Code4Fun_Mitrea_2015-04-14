using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code4Fun;
using System.Collections.Generic;

namespace UnitTestCode4Fun
{
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
        IList<TSVData> data = new List<TSVData>();

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

            Algorithm a = new Algorithm();

            foreach (TSVData item in data)
            {
               if( a.Statistics(ref averageLatency, ref totalBandwidth, item.latency_ms, item.bandwidth))
               {

               }
               else
               {

               }
            }
        }
    }
}
