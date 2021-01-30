using System;
using System.Collections.Generic;

namespace Sween.Core.Entities
{
    public partial class UsersGroup
    {
        public int IdUsergroup { get; set; }
        public int IdUser { get; set; }
        public int IdGroup { get; set; }

        public virtual Groups IdGroupNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
