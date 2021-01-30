using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.CustomEntities
{
    public class Metadata
    {
        

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string NextPageURL { get; set; }
        public string PreviousPageURL { get; set; } 
    }
}
