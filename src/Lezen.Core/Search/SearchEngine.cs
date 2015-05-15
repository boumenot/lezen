using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.QueryParsers;

namespace Lezen.Core.Search
{
    public class SearchEngine : IDisposable
    {
        private readonly Directory directory;
        private readonly StandardAnalyzer analyzer;
        private readonly IndexWriter indexWriter;

        private readonly DocumentFactory factory;

        public SearchEngine(string path)
        {
            this.directory = FSDirectory.Open(path);
            this.analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            this.indexWriter = new IndexWriter(this.directory, analyzer, new IndexWriter.MaxFieldLength(int.MaxValue));

            this.factory = new DocumentFactory();
        }

        public IEnumerable<IDocument> Query(string q)
        {
            var parser = new MultiFieldQueryParser(
                Lucene.Net.Util.Version.LUCENE_30,
                new[] { Constants.Search.Abstract, Constants.Search.Text },
                this.analyzer);

            var query = parser.Parse(q);
            return this.Query(query);
        }

        public IEnumerable<IDocument> Query(int entityID)
        {
            var term = new Term(Constants.Search.EntityID, entityID.ToString());
            var q = new TermQuery(term);

            return this.Query(q);
        }

        public void Insert(SearchItem searchItem) 
        {
            var doc = this.factory.Create(searchItem);
            this.indexWriter.AddDocument(doc);
        }

        public void Dispose()
        {
            this.indexWriter.Commit();

            using (this.indexWriter)
            using (this.analyzer)
            using (this.directory) { }
        }

        private IEnumerable<IDocument> Query(Query query)
        {
            using (var reader = this.indexWriter.GetReader())
            using (var searcher = new IndexSearcher(reader))
            {
                var docs = searcher.Search(query, 100);

                for (int i = 0; i < docs.TotalHits; i++)
                {
                    var offset = docs.ScoreDocs[i].Doc;
                    var doc = reader[offset];

                    yield return SearchDocument.Create(doc);
                }
            }
        }
    }
}
