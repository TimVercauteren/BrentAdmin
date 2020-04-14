using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SecretManager : ISecretManager
    {
        private const string KeyvaultAdress = "https://brentkluis.vault.azure.net/";

        public async Task<string> GetSecretAsync(string secretName)
        {
            //int attempt = 0;
            try
            {
                return await GetFromKeyVault(secretName);
            }
            catch (KeyVaultErrorException exception)
            {
                return exception.Message;
            }
        }

        private static async Task<string> GetFromKeyVault(string secretName)
        {
            AzureServiceTokenProvider tokenprovider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenprovider.KeyVaultTokenCallback));

            var secret = await keyVaultClient.GetSecretAsync($"{KeyvaultAdress}/secrets/{secretName}");

            return secret.Value;
        }
    }
}
