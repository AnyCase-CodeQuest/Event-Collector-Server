using System;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace EventCollectorServer.Api.Extensions
{
	/// <summary>
	/// Provides extension methods used during the application configuration.
	/// </summary>
	internal static class ConfigurationExtensions
	{
		#region Public Methods

		/// <summary>
		/// Adds the azure secrets.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <returns>The same <see cref="ConfigurationBinder"/> instance which has been passed to the method.</returns>
		public static IConfigurationBuilder AddAzureSecrets(this IConfigurationBuilder builder)
		{
			string keyVaultEndpoint = GetKeyVaultEndpoint();

			if (!string.IsNullOrEmpty(keyVaultEndpoint))
			{
				AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
				KeyVaultClient keyVaultClient = new KeyVaultClient(
					new KeyVaultClient.AuthenticationCallback(
						azureServiceTokenProvider.KeyVaultTokenCallback));
				builder.AddAzureKeyVault(
					keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
			}

			return builder;
		}

		#endregion

		#region Private Methods

		private static string GetKeyVaultEndpoint() => Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");

		#endregion
	}
}
