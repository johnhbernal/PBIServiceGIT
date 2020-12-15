using InventoryService.Models;
using Microsoft.Extensions.Options;
using System;
using System.DirectoryServices;

namespace PBIServices.Ldap
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        //public Boolean estado;
        //private const string DisplayNameAttribute = "DisplayName";
        //private const string mail = "mail";
        private const string SAMAccountNameAttribute = "SAMAccountName";
        private readonly LdapConfig config;

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            this.config = config.Value;
        }

        //public UserInfo Login(string UserName, string Password)
        public UserInfo Login(string UserName)
        {
            try
            {
                ///*using (DirectoryEntry entry = new DirectoryEntry(config.Path + config.UserDomainName, UserName, Password))*/
                using (DirectoryEntry entry = new DirectoryEntry(config.Path + config.UserDomainName))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, UserName);

                        //searcher.PropertiesToLoad.Add(DisplayNameAttribute);  //no usado

                        searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);

                        //searcher.PropertiesToLoad.Add(Password); // no usado

                        var result = searcher.FindOne();

                        if (result != null)
                        {
                            //var displayName = result.Properties[DisplayNameAttribute];
                            //var email = result.Properties[mail];
                            var samAccountName = result.Properties[SAMAccountNameAttribute];
                            //var password = result.Properties[Password];

                            return new UserInfo
                            {
                                //DisplayName = displayName == null || displayName.Count <= 0 ? null : displayName[0].ToString(),
                                //Password = password == null || password.Count <= 0 ? null : password[0].ToString(),
                                UserName = samAccountName == null || samAccountName.Count <= 0 ? null : samAccountName[0].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if we get an error, it means we have a login failure.
                // Log specific exception
                //estado = false;
                Funciones.Logs("LdapAuthenticationService", "Problemas al abrir la conexion; Captura error: " + ex.Message);
                Funciones.Logs("LdapAuthenticationService_DEBUG", ex.StackTrace);
            }

            return null;
            //return estado;
        }
    }
}