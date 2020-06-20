using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pic.Authorization.Configuration
{
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expiry { get; set; }
    }
}
