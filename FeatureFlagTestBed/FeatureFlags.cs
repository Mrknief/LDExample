using LaunchDarkly.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagTestBed
{
    public static class FeatureFlags
    {
        public const string PerPersonFlag = "per-person-flag";
        public const string IntValueFlag = "turn-it-up-to-eleven-flag";
        public const string UserGroupFlag = "user-group-flag";
        public const string SegmentationFlag = "segmentation-flag";
    }
}
