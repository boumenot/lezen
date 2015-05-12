﻿using Lezen.Core.Entity;
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

        [Fact]
        public void AuthorEntityShouldRoundTrip()
        {
            using (var factory = new SqlCompactFactory())
            {
                using (var context = factory.Create())
                {
                    var document = new Author
                    {
                        FirstName = "Jerry",
                        LastName = "Garcia",
                        Email = "jerry.garcia@thedead.net",
                    };

                    context.Authors.Add(document);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Authors.Should().HaveCount(1);
                    var author = context.Authors.First();
                    author.FirstName.Should().Be("Jerry");
                    author.LastName.Should().Be("Garcia");
                    author.Email.Should().Be("jerry.garcia@thedead.net");
                }
            }
        }
    }
}
