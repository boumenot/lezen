using Lezen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Lezen.Core.Test.Entity
{
    public class _01_RoundTripEntity
    {
        [Fact]
        public void DocumentEntityShouldRoundTrip()
        {
            using (var factory = new SqlCompactFactory())
            {
                using (var context = factory.Create())
                {
                    var document = new Document()
                    {
                        Title = "--title--",
                    };

                    context.Documents.Add(document);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Documents.Should().HaveCount(1);
                    context.Documents.First().Title.Should().Be("--title--");
                }
            }
        }
    }
}
