using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezen.Core.Search
{
    public sealed class SearchDocument : IDocument
    {
        private readonly Document document;

        private SearchDocument(Document document)
        {
            this.document = document;
        }

        public int EntityID { get { return int.Parse(this.document.Get(Constants.Search.EntityID)); } }
        public string Abstract { get { return this.document.Get(Constants.Search.Abstract); } }
        public string Text { get { return this.document.Get(Constants.Search.Text); } }
        public string[] Keywords { get { return this.document.GetValues(Constants.Search.Keyword); } }

        public static SearchDocument Create(Document document)
        {
            return new SearchDocument(document);
        }
    }
}
