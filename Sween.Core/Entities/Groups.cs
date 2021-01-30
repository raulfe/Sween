using System;
using System.Collections.Generic;

namespace Sween.Core.Entities
{
    public partial class Groups
    {
        public Groups()
        {
            UsersGroup = new HashSet<UsersGroup>();
        }

        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<UsersGroup> UsersGroup { get; set; }
    }
}
