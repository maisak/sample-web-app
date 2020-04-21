using NUnit.Framework;
using Sample.Common.Toolbox;
using System;

namespace Sample.UnitTests.Common.Toolbox
{
    [TestFixture]
    public class EnvironmentConfigTests
    {
        private const string InstanceIdValue = "test-instance-key";
        private const string SettableGetValue = "test-settable-get";
        private const string SettableSetValue = "test-settable-set";
        private const string KeyVaultUrlValue = "test-url";

        [OneTimeSetUp]
        public void Setup()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariables.IsStaging, bool.TrueString);
            Environment.SetEnvironmentVariable(EnvironmentVariables.InstanceId, InstanceIdValue);
            Environment.SetEnvironmentVariable(EnvironmentVariables.Settable, SettableGetValue);
            Environment.SetEnvironmentVariable(EnvironmentVariables.KeyVaultUrl, KeyVaultUrlValue);
        }

        [Test]
        public void KeyVaultUrlTest()
        {
            var keyVaultUrl = EnvironmentConfig.KeyVaultUrl;
            Assert.AreEqual(keyVaultUrl, KeyVaultUrlValue);
        }

        [Test]
        public void IsStagingTest()
        {
            var isStaging = EnvironmentConfig.IsStaging;
            Assert.IsTrue(isStaging);
        }

        [Test]
        public void InstanceIdTest()
        {
            var instanceId = EnvironmentConfig.InstanceId;
            Assert.AreEqual(instanceId, InstanceIdValue);
        }

        [Test]
        public void SettableGetTest()
        {
            var settable = EnvironmentConfig.Settable;
            Assert.AreEqual(SettableGetValue, settable);
        }

        [Test]
        public void SettableSetTest()
        {
            EnvironmentConfig.Settable = SettableSetValue;
            var tfsoSessionId = EnvironmentConfig.Settable;
            Assert.AreEqual(SettableSetValue, tfsoSessionId);
        }
    }
}