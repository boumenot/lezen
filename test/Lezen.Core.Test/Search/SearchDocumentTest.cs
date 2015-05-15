using Lezen.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Lezen.Core.Test.Search
{
    public class SearchDocumentTest
    {
        [Fact]
        public void Test()
        {
             var searchItem = new SearchItem
            {
                EntityID = 1,
                Abstract = "--abstract--",
                Keywords = new[] { "keyword1", "keyword2", "keyword3" },
                Text = "--text--",
            };

            var documentFactory = new DocumentFactory();
            var document = documentFactory.Create(searchItem);

            var testSubject = SearchDocument.Create(document);
            testSubject.Abstract.Should().Be("--abstract--");
            testSubject.EntityID.Should().Be(1);
            testSubject.Keywords.Should().ContainInOrder("keyword1", "keyword2", "keyword3");
            testSubject.Text.Should().Be("--text--");
        }
    }
}
