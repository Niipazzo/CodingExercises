using Niipazzo.Exercises;
using System;

namespace Niipazzo.Tools
{
    public class Metrics
    {
        public static long Run(IExercise testSubject, bool noRender = false)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            testSubject.Solve();
            sw.Stop();
            if (!noRender)
                testSubject.Render();

            //Console.WriteLine($"Time taken to solve: {sw.ElapsedMilliseconds}ms");

            return sw.ElapsedMilliseconds;
        }
    }
}
