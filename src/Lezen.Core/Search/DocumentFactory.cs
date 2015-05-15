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
            var document = new Lucene.Net.Documents.Document();

            foreach (var keyword in searchItem.Keywords)
            {
                document.Add(this.CreateKeywordField(Constants.Search.Keyword, keyword));
            }

            document.Add(this.CreateStoredField(Constants.Search.EntityID, searchItem.EntityID.ToString()));
            document.Add(this.CreateIndexedTextField(Constants.Search.Abstract, searchItem.Abstract));
            document.Add(this.CreateIndexedTextField(Constants.Search.Text, searchItem.Text));

            return document;
        }

        private Field CreateStoredField(string name, string value)
        {
            return new Field(name, value, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO);
        }

        private Field CreateKeywordField(string name, string value)
        {
            return new Field(name, value, Field.Store.NO, Field.Index.ANALYZED);
        }

        private Field CreateIndexedTextField(string name, string value)
        {
            return new Field(name, value, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
        }
    }
}
