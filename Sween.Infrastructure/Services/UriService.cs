using Sween.Core.QueryFilters;
using Sween.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Services
{
    public class UriService : IUriService
    {

        private readonly string _basUri;
        public UriService(string baseUri)
        {
            _basUri = baseUri;
        }   
        public Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_basUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
