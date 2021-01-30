using Sween.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.Entities
{
    public class Security
    {
        public int IdSecurity { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public RoleType Rol { get; set; }
    }
}
