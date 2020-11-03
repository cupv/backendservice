using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Test.Controllers.Infrastructure
{
    public class ODataRequest
    {
        public int Top { get; set; }
        public int Skip { get; set; }
        public string OrderBy { get; set; }
        public string Filter { get; set; }
    }

    public class PagingDataSource<T> where T : class
    {
        public int Total { get; set; }

        public T Data { get; set; }

    }
}
