using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity
{
    public static class IdentityConfiguration
    {
        public static List<ApiScope> Scopes => new List<ApiScope>()
        {
            new ApiScope("API")
        };

        public static List<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Address(),
            new IdentityResources.Email()
        };

        public static List<ApiResource> ApiResources => new List<ApiResource>()
        {
            new ApiResource("API","ServerAPI")
        };

        public static List<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "blazor_client",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RedirectUris=
                {
                    "https://localhost:44347/authentication/login-callback"
                },
                AllowedCorsOrigins=
                {
                    "https://localhost:44347"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:44347/authentication/logout-callback"
                },
                AllowedScopes = 
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.Email,
                },
                AllowAccessTokensViaBrowser = true
            }
        };
    }
}
