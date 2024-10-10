using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    /// <summary>
    /// MySQL context
    /// </summary>
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {
        //----------------------------------------//
        //          Construtor                    //
        //----------------------------------------//
        /// <summary>
        /// Contrutor base
        /// </summary>
        /// <param name="options"></param>
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
    }
}
