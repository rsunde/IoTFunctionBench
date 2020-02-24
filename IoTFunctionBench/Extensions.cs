using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Diagnostics;

namespace IoTFunctionBench
{
    public static class Extensions
    {
        public static string ToStringRows(this List<string> list, string paddingString)
        {
            var resultOutput = string.Empty;
            foreach (var inf in list)
            {
                if (inf == Environment.NewLine)
                {
                    resultOutput += inf;
                }
                else
                {
                    resultOutput += $"{paddingString}{inf}{Environment.NewLine}";
                }
            }

            return resultOutput;
        }

        public static void Add(this List<string> list) => list.Add(Environment.NewLine);

        public static string Benchmark(int iterations)
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Guid.NewGuid();
            }
            stopwatch.Stop();

            return $"Generated {iterations} GUIDs in {stopwatch.Elapsed}.";
        }
    }
}
