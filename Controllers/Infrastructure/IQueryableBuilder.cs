using System.Linq;
using Community.OData.Linq;

namespace Test.Controllers.Infrastructure
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ParseOData<T>(this IQueryable<T> query, ODataRequest request)
        {
            var _query = query.OData();

            if (request.Filter != null)
            {
                _query = _query.Filter(request.Filter);
            }

            if (request.OrderBy != null)
            {
                _query = _query.OrderBy(request.OrderBy);
            }

            if (request.Top != 0)
            {
                _query = _query.TopSkip(request.Top.ToString(), null);
            }
            if (request.Skip != 0)
            {
                _query = _query.TopSkip(null, request.Skip.ToString());
            }
            return _query;
        }
    }
}
