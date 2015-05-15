using Lezen.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Lezen.Core.Test.Search
{
    public class SearchEngineTest
    {
        [Fact(Skip = "Too much for a unit test.")]
        public void QueryShouldSearchByEntityID()
        {
            using (var temp = new TempDirectory(Directory.GetCurrentDirectory()))
            using (var testSubject = new SearchEngine(temp.Path))
            {
                var searchItem1 = new SearchItem
                {
                    EntityID = 1,
                    Abstract = "--abstract--",
                    Keywords = new[] { "keyword1", "keyword2" },
                    Text = "--text--",
                };

                var searchItem2 = new SearchItem { EntityID = 2, Abstract = "--abstract2--", Text = "--text2--", Keywords = new string[0] };

                testSubject.Insert(searchItem1);
                testSubject.Insert(searchItem2);

                var documents = testSubject.Query(1);
                documents.Should().HaveCount(1);

                var document = documents.First();
                document.EntityID.Should().Be(1);
                document.Abstract.Should().Be("--abstract--");
                document.Text.Should().Be("--text--");
            }
        }

        [Fact(Skip="Too much for a unit test.")]
        public void QueryShouldReturnDocumentsInSearchEngine()
        {
            using (var temp = new TempDirectory(Directory.GetCurrentDirectory()))
            using (var testSubject = new SearchEngine(temp.Path))
            {
                var searchItem1 = new SearchItem
                {
                    EntityID = 1,
                    Abstract = "--abstract1--",
                    Keywords = new[] { "keyword1", "keyword2" },
                    Text = "--text TERM--",
                };

                var searchItem2 = new SearchItem { EntityID = 2, Abstract = "--abstract2--", Text = "--text TERM--", Keywords = new string[0] };

                testSubject.Insert(searchItem1);
                testSubject.Insert(searchItem2);

                var documents = testSubject.Query("TERM");
                documents.Should().HaveCount(2);

                documents.Select(x => x.EntityID).Should().Contain(new[] { 1, 2 });
            }
        }

        [Fact(Skip = "Too much for a unit test.")]
        public void EngineShouldDeleteDocuments()
        {
            using (var temp = new TempDirectory(Directory.GetCurrentDirectory()))
            using (var testSubject = new SearchEngine(temp.Path))
            {
                var searchItem1 = new SearchItem { EntityID = 1, Abstract = "--abstract--", Text = "--text--", Keywords = new string[0] };
                testSubject.Insert(searchItem1);

                testSubject.Query(1).Should().HaveCount(1);
                testSubject.Delete(1);
                testSubject.Query(1).Should().HaveCount(0);
            }
        }
    }
}
