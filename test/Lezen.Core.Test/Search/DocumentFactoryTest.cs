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
    public class DocumentFactoryTest
    {
        [Fact]
        public void DocumentShouldHaveCorrectFieldNames()
        {
            var searchItem = new SearchItem
            {
                Abstract = "--abstract--",
                Keywords = new[] { "keyword1", "keyword2", "keyword3" },
                Text = "--text--",
            };

            var testSubject = new DocumentFactory();
            var document = testSubject.Create(searchItem);

            var fields = document.GetFields();
            var names = String.Join(",", fields.Select(x => x.Name).ToArray());
            //names.Should().Be("donkey");

            fields.Any(x => x.Name == "Abstract").Should().BeTrue();
            fields.Any(x => x.Name == "Text").Should().BeTrue();
            fields.Count(x => x.Name == "Keyword").Should().Be(3);

            document.Get("Abstract").Should().Be("--abstract--");
            document.Get("Text").Should().Be("--text--");
            document.GetValues("Keyword").Should().HaveCount(3);
            document.GetValues("Keyword").Should().Contain("keyword1", "keyword2", "keyword3");
        }

        [Fact]
        public void AbstractShouldBeAnalyzedField()
        {
            var searchItem = new SearchItem
            {
                Abstract = "--abstract--",
                Keywords = new[] { "keyword1", "keyword2", "keyword3" },
                Text = "--text--",
            };

            var testSubject = new DocumentFactory();
            var document = testSubject.Create(searchItem);

            var abstractField = document.GetField("Abstract");
            abstractField.IsBinary.Should().BeFalse();
            abstractField.IsIndexed.Should().BeTrue();
            abstractField.IsLazy.Should().BeFalse();
            abstractField.IsStored.Should().BeTrue();
            abstractField.IsStoreOffsetWithTermVector.Should().BeTrue();
            abstractField.IsStorePositionWithTermVector.Should().BeTrue();
            abstractField.IsTermVectorStored.Should().BeTrue();
            abstractField.IsTokenized.Should().BeTrue();
            abstractField.OmitNorms.Should().BeFalse();
            abstractField.OmitTermFreqAndPositions.Should().BeFalse();
        }

        [Fact]
        public void TextShouldBeAnalyzedField()
        {
            var searchItem = new SearchItem
            {
                Abstract = "--abstract--",
                Keywords = new[] { "keyword1", "keyword2", "keyword3" },
                Text = "--text--",
            };

            var testSubject = new DocumentFactory();
            var document = testSubject.Create(searchItem);

            var abstractField = document.GetField("Text");
            abstractField.IsBinary.Should().BeFalse();
            abstractField.IsIndexed.Should().BeTrue();
            abstractField.IsLazy.Should().BeFalse();
            abstractField.IsStored.Should().BeTrue();
            abstractField.IsStoreOffsetWithTermVector.Should().BeTrue();
            abstractField.IsStorePositionWithTermVector.Should().BeTrue();
            abstractField.IsTermVectorStored.Should().BeTrue();
            abstractField.IsTokenized.Should().BeTrue();
            abstractField.OmitNorms.Should().BeFalse();
            abstractField.OmitTermFreqAndPositions.Should().BeFalse();
        }

        [Fact]
        public void KeywordShouldBeAnalyzedField()
        {
            var searchItem = new SearchItem
            {
                Abstract = "--abstract--",
                Keywords = new[] { "keyword1", "keyword2", "keyword3" },
                Text = "--text--",
            };

            var testSubject = new DocumentFactory();
            var document = testSubject.Create(searchItem);

            var abstractField = document.GetField("Keyword");
            abstractField.IsBinary.Should().BeFalse();
            abstractField.IsIndexed.Should().BeTrue();
            abstractField.IsLazy.Should().BeFalse();
            abstractField.IsStored.Should().BeFalse();
            abstractField.IsStoreOffsetWithTermVector.Should().BeFalse();
            abstractField.IsStorePositionWithTermVector.Should().BeFalse();
            abstractField.IsTermVectorStored.Should().BeFalse();
            abstractField.IsTokenized.Should().BeTrue();
            abstractField.OmitNorms.Should().BeFalse();
            abstractField.OmitTermFreqAndPositions.Should().BeFalse();
        }

    }
}
