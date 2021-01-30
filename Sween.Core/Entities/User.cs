using System;
using System.Collections.Generic;

namespace Sween.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Messages>();
            UsersGroup = new HashSet<UsersGroup>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<UsersGroup> UsersGroup { get; set; }
    }
}
