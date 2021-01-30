using Sween.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Interfaces
{
    public interface IUriService
    {

        Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl);
    }
}
