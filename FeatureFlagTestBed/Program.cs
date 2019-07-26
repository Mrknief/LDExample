using System;
using LaunchDarkly.Client;

namespace FeatureFlagTestBed
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            demo.Run();
        }
    }
}
