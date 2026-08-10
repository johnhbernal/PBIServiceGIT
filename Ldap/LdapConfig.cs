namespace PBIServices.Ldap
{
    public class LdapConfig
    {
        public string Path { get; set; }
        public string UserDomainName { get; set; }

        /// <summary>When false, Token endpoint skips directory checks (local/dev).</summary>
        public bool Enabled { get; set; }

        /// <summary>Ignored in teaching lab (no real bind). Kept for config compatibility.</summary>
        public bool RequireBind { get; set; }

        /// <summary>Always Simulated in this teaching lab.</summary>
        public string Mode { get; set; } = "Simulated";
    }
}
