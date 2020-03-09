using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System.Threading.Tasks;

namespace Sample.Common.Toolbox
{
    public class AzureKeyVault : IKeyVault
    {
        private readonly string _keyVaultUrl = EnvironmentConfig.KeyVaultUrl;
        private readonly KeyVaultClient _keyVaultClient;

        public AzureKeyVault()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            _keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        }

        public async Task<string> GetSecret(string value)
        {
            var secret = await _keyVaultClient.GetSecretAsync($"{_keyVaultUrl}/secrets/{value}")
                    .ConfigureAwait(false);
            return secret.Value;
        }
    }
}
