using InventoryService.Models;
using System;
using System.Collections.Generic;

namespace PBIServices.Ldap
{
    /// <summary>
    /// Teaching AD simulation (Practica pattern). No network / no real LDAP.
    /// </summary>
    public class SimulatedDirectoryService : IAuthenticationService
    {
        private static readonly HashSet<string> DemoUsers = new(StringComparer.OrdinalIgnoreCase)
        {
            "admin",
            "seller",
            "demo.user"
        };

        public UserInfo Login(string userName, string password = null)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return null;
            }

            if (!DemoUsers.Contains(userName.Trim()))
            {
                Funciones.Logs("SimulatedDirectory", "Unknown demo directory user: " + userName);
                return null;
            }

            return new UserInfo { UserName = userName.Trim() };
        }
    }
}
