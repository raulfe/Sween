using System;
using System.Collections.Generic;

namespace Sween.Core.Entities
{
    public partial class Messages
    {
        public int IdMessage { get; set; }
        public string View { get; set; }
        public string Type { get; set; }
        public string Contain { get; set; }
        public string Reaction { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
