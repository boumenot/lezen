using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Search
{
    public class SearchEngine
    {
        public IEnumerable<IDocument> Query(string q)
        {
            return Enumerable.Empty<IDocument>();
        }
    }
}
