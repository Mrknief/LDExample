using LaunchDarkly.Client;

namespace FeatureFlagTestBed
{
    public static class LaunchDarklyConfig
    {
        public static LdClient Configure()
        {
            LdClient client = new LdClient("sdk-6502c370-4a72-4f21-ba25-3c60bc389385");

            return client;
        }
    }
}
