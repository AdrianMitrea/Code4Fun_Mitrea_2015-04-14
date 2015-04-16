using System;
using System.Collections.Generic;
using System.Linq;

namespace Code4Fun
{
    public struct TSVData
    {
        public string file_name;
        public int num_connections;
        public int latency_ms;
        public int bandwidth;
    }

    public class Algorithm
    {
        ///<summary>
        ///method which calculates the average latency and total bandwidth taking data from headers of TSV files (preloded in a data structure)
        ///</summary>
        public bool Statistics(ref double average, ref double total, List<TSVData> data)
        {
            if (data == null)
            {
                throw new NullReferenceException("There are no data to process");
            }

            foreach (TSVData item in data)
            {
                if (item.latency_ms <= 0 || item.bandwidth <= 0)
                {
                    throw new ArgumentOutOfRangeException("Input values are negative");
                }

                average += item.latency_ms;
                total += item.bandwidth;
            }

            if (data.Count() == 0)
            {
                throw new DivideByZeroException("Division by Zero. There are no data to process");
            }

            average /= data.Count();
            return true;
        }
    }
}
