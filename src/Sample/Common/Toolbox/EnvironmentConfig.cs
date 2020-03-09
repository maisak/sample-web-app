using System;

namespace Sample.Common.Toolbox
{
    public static class EnvironmentConfig
    {
        private const string IsStagingName = "IS_STAGING";
        private const string InstanceIdName = "INSTANCE_ID";
        private const string SettableName = "SETTABLE_VARIABLE";
        private const string KeyVaultUrlName = "KEY_VAULT_URL";

        public static string Settable
        {
            get => Environment.GetEnvironmentVariable(SettableName);
            set => Environment.SetEnvironmentVariable(SettableName, value);
        }

        public static string InstanceId => Environment.GetEnvironmentVariable(InstanceIdName);
        public static string KeyVaultUrl => Environment.GetEnvironmentVariable(KeyVaultUrlName);
        public static bool IsStaging => Environment.GetEnvironmentVariable(IsStagingName) == bool.TrueString;
    }
}
