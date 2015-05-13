using Lezen.Core.Search;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Lezen.Core.Test.Search
{
    public class _01_QueryIndex
    {
        [Fact(Skip="Too much for a unit test")]
        public void Test()
        {
            using (var temp = new TempDirectory(System.IO.Directory.GetCurrentDirectory()))
            using (var directory = FSDirectory.Open(temp.Path))
            {
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

                IndexWriter.MaxFieldLength length = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
                var writer = new IndexWriter(directory, analyzer, length);

                var documentFactory = new DocumentFactory();
                var searchItem1 = new SearchItem { EntityID = 1, Abstract = "abstract1", Keywords = new string[0], Text = "text1" };
                var searchItem2 = new SearchItem { EntityID = 2, Abstract = "abstract2", Keywords = new string[0], Text = "text2" };
                var searchItem3 = new SearchItem { EntityID = 3, Abstract = "abstract3", Keywords = new string[0], Text = "text3" };

                writer.AddDocument(documentFactory.Create(searchItem1));
                writer.AddDocument(documentFactory.Create(searchItem2));
                writer.AddDocument(documentFactory.Create(searchItem3));

                writer.Commit();

                writer.NumDocs().Should().Be(3);
                writer.Dispose();
            }
        }
    }
}
