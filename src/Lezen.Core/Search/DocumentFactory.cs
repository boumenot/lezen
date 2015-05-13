using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Documents;

namespace Lezen.Core.Search
{
    public class DocumentFactory
    {
        public Document Create(SearchItem searchItem)
        {
            var document = new Document();

            foreach (var keyword in searchItem.Keywords)
            {
                document.Add(
                    new Field("Keyword", keyword, Field.Store.YES, Field.Index.ANALYZED));
            }

            document.Add(
                new Field("Abstract", searchItem.Abstract, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
            document.Add(
                new Field("Text", searchItem.Text, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));

            return document;
        }
    }
}
