using System;

namespace Sample.Common.Toolbox
{
    internal static class EnvironmentConfig
    {
        internal static string Settable
        {
            get => Environment.GetEnvironmentVariable(EnvironmentVariables.Settable);
            set => Environment.SetEnvironmentVariable(EnvironmentVariables.Settable, value);
        }

        internal static string InstanceId => Environment.GetEnvironmentVariable(EnvironmentVariables.InstanceId);
        internal static string KeyVaultUrl => Environment.GetEnvironmentVariable(EnvironmentVariables.KeyVaultUrl);
        internal static bool IsStaging => Environment.GetEnvironmentVariable(EnvironmentVariables.IsStaging) == bool.TrueString;
    }

    internal struct EnvironmentVariables
    {
        internal const string IsStaging  = "IS_STAGING";
        internal const string InstanceId  = "INSTANCE_ID";
        internal const string Settable  = "SETTABLE_VARIABLE";
        internal const string KeyVaultUrl  = "KEY_VAULT_URL";
    }
}
