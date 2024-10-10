using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    /// <summary>
    /// Classe de configuração do Identity
    /// </summary>
    public static class IdentityConfiguration
    {
        /// <summary>
        /// Role Admin
        /// </summary>
        public const string Admin = "Admin";
        
        /// <summary>
        /// Role Client
        /// </summary>
        public const string Client = "Client";

        /// <summary>
        /// Recursos
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        /// <summary>
        /// Scope
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data.")
            };

        /// <summary>
        /// Clientes
        /// </summary>
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("fadshdgsGFASDGqdfafgYHJmnGbb635423GHGK8%35rrwrw".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read", "write", "profile"}
            },
            new Client
            {
                ClientId = "geek_shopping",
                ClientSecrets = { new Secret("fadshdgsGFASDGqdfafgYHJmnGbb635423GHGK8%35rrwrw".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:4430/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:4430/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "geek_shopping"
                }
            }
        };
    }
}
