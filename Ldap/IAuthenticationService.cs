using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBIServices.Ldap
{
   public interface IAuthenticationService
    {
        UserInfo Login(string UserName, string Password);
    }
}
