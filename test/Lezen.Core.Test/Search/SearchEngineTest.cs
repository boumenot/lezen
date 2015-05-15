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
    public class SearchEngineTest
    {
        [Fact]
        public void Test()
        {
            var testSubject = new SearchEngine();
            testSubject.Query(string.Empty).Should().BeEmpty();
        }
    }
}
