using System;
using System.Threading;
using StackExchange.Profiling;

namespace Web
{
    public class FakeHttpCall
    {
        public static string Call(string text)
        {
            using (MiniProfiler.Current.CustomTiming("http", string.Empty, "Get"))
            {
                var delay = new Random().Next(100, 400);

                Thread.Sleep(delay);

                return text;
            }
        }
    }
}
