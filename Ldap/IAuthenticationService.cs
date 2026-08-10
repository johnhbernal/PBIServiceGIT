using InventoryService.Models;

namespace PBIServices.Ldap
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Directory check. Password used only when Ldap:RequireBind=true.
        /// </summary>
        UserInfo Login(string userName, string password = null);
    }
}
