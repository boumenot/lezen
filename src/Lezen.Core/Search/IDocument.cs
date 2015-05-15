using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Search
{
    public interface IDocument
    {
        int EntityID { get; }
        string Abstract { get; }
        string Text { get; }
        string[] Keywords { get; }
    }
}
