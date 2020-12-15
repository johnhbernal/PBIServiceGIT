using InventoryService.Models;

namespace PBIServices.Ldap
{
    public interface IAuthenticationService
    {
        //UserInfo Login(string UserName, string Password);
        UserInfo Login(string UserName);
    }
}