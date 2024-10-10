using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    /// <summary>
    /// Classe de inicialização do DB
    /// </summary>
    public class DbInitializer : IDbInitializer
    {
        /// <summary>
        /// MySQL context
        /// </summary>
        private readonly MySQLContext _context;

        /// <summary>
        /// Usuário
        /// </summary>
        private readonly UserManager<ApplicationUser> _user;

        /// <summary>
        /// Role
        /// </summary>
        private readonly RoleManager<IdentityRole> _role;

        /// <summary>
        /// Contrutuor padrão
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
        public DbInitializer(MySQLContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        /// <summary>
        /// Criação do admin e client padrão
        /// </summary>
        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "douglas-admin",
                Email = "douglas-admin@erudio.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (31) 12345-6789",
                FirstName = "Douglas",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Admin@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "douglas-client",
                Email = "douglas-client@erudio.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (31) 12345-6789",
                FirstName = "Douglas",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Admin@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
