using System;

namespace Sample.Common.Toolbox
{
    public static class EnvironmentConfig
    {
        private const string IsStagingName = "IS_STAGING";
        private const string InstanceIdName = "INSTANCE_ID";
        private const string SettableName = "SETTABLE_VARIABLE";

        public static string Settable
        {
            get => Environment.GetEnvironmentVariable(SettableName);
            set => Environment.SetEnvironmentVariable(SettableName, value);
        }

        public static string InstanceId => Environment.GetEnvironmentVariable(InstanceIdName);
        public static bool IsStaging => Environment.GetEnvironmentVariable(IsStagingName) == bool.TrueString;
    }
}
