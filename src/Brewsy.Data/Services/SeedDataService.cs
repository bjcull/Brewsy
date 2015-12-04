using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;
using Brewsy.Domain.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Brewsy.Data.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly BrewsyContext _brewsyContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 

        public SeedDataService(BrewsyContext brewsyContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _brewsyContext = brewsyContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task EnsureSeedDataExists()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!_userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "bjcull@gmail.com",
                    Email = "bjcull@gmail.com"
                };
                await _userManager.CreateAsync(user, "P@ssword1");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
