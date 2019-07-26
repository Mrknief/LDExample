using System;
using LaunchDarkly.Client;

namespace FeatureFlagTestBed
{
    public class Flag<T>
    {
        private Func<string, User, T, T> _evaluationFunction;
        private T _default;

        public string Key { get; protected set; }

        public Flag(string key, Func<string, User, T, T> evalFunc, T defaultValue)
        {
            Key = key;
            _evaluationFunction = evalFunc;
            _default = defaultValue;
        }

        public T Evaluate(User user)
        {
            return _evaluationFunction(Key, user, _default);
        }
    }   
}
