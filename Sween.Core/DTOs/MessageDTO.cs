using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class MessageDTO
    {
        public int IdMessage { get; set; }
        public string View { get; set; }
        public string Type { get; set; }
        public string Contain { get; set; }
        public string Reaction { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }
}
