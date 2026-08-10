using InventoryService.Models;
using Microsoft.Extensions.Options;

namespace PBIServices.Ldap
{
    /// <summary>
    /// Legacy name kept for DI compatibility.
    /// Teaching lab: always delegates to <see cref="SimulatedDirectoryService"/> — never opens real LDAP.
    /// </summary>
    public class LdapAuthenticationService : IAuthenticationService
    {
        private readonly SimulatedDirectoryService _simulated = new SimulatedDirectoryService();

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            // Config retained for docs/demo flags only; no network bind.
            _ = config;
        }

        public UserInfo Login(string userName, string password = null)
            => _simulated.Login(userName, password);
    }
}
