using System;
using System.Collections.Generic;
using LaunchDarkly.Client;

namespace FeatureFlagTestBed
{
    public class Demo : IDisposable
    {
        private List<User> _users;
        private List<Flag<bool>> _boolFlags;
        private List<Flag<int>> _intFlags;
        private readonly LdClient _client;

        public Demo()
        {
            _client = LaunchDarklyConfig.Configure();

            PopulateUsers();
            PopulateFlags();
        }

        public void Run()
        {
            foreach(Flag<bool> flag in _boolFlags)
            {
                foreach (User user in _users)
                {
                    ShowUserEnabledFeatures(flag.Evaluate(user), flag.Key, user);
                }
            }

            foreach (Flag<int> flag in _intFlags)
            {
                foreach (User user in _users)
                {
                    ShowUserEnabledFeatures(flag.Evaluate(user), flag.Key, user);
                }
            }


            Console.WriteLine("Press 'r' to Rerun");

            if(Console.ReadKey().KeyChar == 'r')
            {
                Console.WriteLine();
                Run();
            }
        }

        private void PopulateUsers()
        {
            _users = new List<User>();

            _users.Add(User.WithKey("FlagShip").AndCustomAttribute("groups", new List<string>() { "flag_fliers", "flag_wavers" }));
            _users.Add(User.WithKey("TestUserOne").AndCustomAttribute("groups", new List<string>() { "flag_wavers" }));
            _users.Add(User.WithKey("SegmentUserA"));
        }

        private void PopulateFlags()
        {
            _boolFlags = new List<Flag<bool>>()
            {
                new Flag<bool>(FeatureFlags.PerPersonFlag, _client.BoolVariation, false),
                new Flag<bool>(FeatureFlags.UserGroupFlag, _client.BoolVariation, false),
                new Flag<bool>(FeatureFlags.SegmentationFlag, _client.BoolVariation, false),
                new Flag<bool>("Flag Doesn't Exist", _client.BoolVariation, true)
            };

            _intFlags = new List<Flag<int>>()
            {
                new Flag<int>(FeatureFlags.IntValueFlag, _client.IntVariation, 1)
            };
        }

        private void ShowUserEnabledFeatures<T>(T value, string flag, User user)
        {
            Console.WriteLine($"Feature: {flag} User: {user.Key} Flag Value: {value}");
        }

        public void Dispose()
        {
            _client.Flush();
            _client.Dispose();
        }
    }
}
