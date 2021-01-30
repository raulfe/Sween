using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.QueryFilters
{
    public class UserQueryFilter
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
