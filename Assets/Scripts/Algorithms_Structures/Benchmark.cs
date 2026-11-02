using System.Diagnostics;
using System;
using UnityEngine;

namespace Utility {
    public class Benchmark {
        public static T RunBenchmark<T>(Func<T> funcToTest) {
            Stopwatch stopwatch = Stopwatch.StartNew();

            T result = funcToTest();

            stopwatch.Stop();
            UnityEngine.Debug.Log($"This Function took: {stopwatch.ElapsedTicks} ticks to complete");

            return result;
        }
    }
}

