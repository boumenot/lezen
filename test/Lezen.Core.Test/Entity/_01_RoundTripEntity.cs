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
                    var author1 = new Author { FirstName = "Jerry", LastName = "Garcia" };
                    var author2 = new Author { FirstName = "Bob", LastName = "Weir" };

                    var document = new Document()
                    {
                        Title = "Truckin",
                    };

                    document.Authors.Add(author1);
                    document.Authors.Add(author2);

                    context.Documents.Add(document);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Documents.Should().HaveCount(1);
                    var document = context.Documents.First();
                    document.Title.Should().Be("Truckin");
                    document.Authors.Should().HaveCount(2);
                    document.Authors.Should().ContainSingle(x => x.LastName == "Weir");
                    document.Authors.Should().ContainSingle(x => x.LastName == "Garcia");

                    var authors = context.Authors.ToArray();
                    authors.Should().HaveCount(2);
                    authors.All(x => x.Documents.Count == 1).Should().BeTrue();
                    authors.All(x => x.Documents.First().ID == document.ID).Should().BeTrue();
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
                    var author = new Author
                    {
                        FirstName = "Jerry",
                        LastName = "Garcia",
                        Email = "jerry.garcia@thedead.net",
                    };

                    var organization = new Organization
                    {
                        Country = "Germany",
                    };

                    author.Organization = organization;

                    context.Authors.Add(author);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Authors.Should().HaveCount(1);
                    var author = context.Authors.First();
                    author.FirstName.Should().Be("Jerry");
                    author.LastName.Should().Be("Garcia");
                    author.Email.Should().Be("jerry.garcia@thedead.net");

                    var organization = author.Organization;
                    organization.Country.Should().Be("Germany");
                }
            }
        }

        [Fact]
        public void OrganizationShouldBeOptionalForAuthor()
        {
            using (var factory = new SqlCompactFactory())
            {
                using (var context = factory.Create())
                {
                    var author = new Author
                    {
                        FirstName = "Jerry",
                        LastName = "Garcia",
                        Email = "jerry.garcia@thedead.net",
                    };

                    context.Authors.Add(author);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Authors.Should().HaveCount(1);
                    var author = context.Authors.First();
                    author.FirstName.Should().Be("Jerry");
                    author.LastName.Should().Be("Garcia");
                    author.Email.Should().Be("jerry.garcia@thedead.net");

                    author.Organization.Should().BeNull();
                }
            }
        }


        [Fact]
        public void OrganizationEntityShouldRoundTrip()
        {
            using (var factory = new SqlCompactFactory())
            {
                using (var context = factory.Create())
                {
                    var organization = new Organization
                    {
                        Institution = "--institution--",
                        Department = "--department--",
                        Country = "Germany",
                        CountryCode = "DE",
                        PostalCode = "66123",
                        Settlement = "Fulda",
                    };

                    context.Organizations.Add(organization);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Organizations.Should().HaveCount(1);
                    var org = context.Organizations.First();
                    org.Institution.Should().Be("--institution--");
                    org.Department.Should().Be("--department--");
                    org.Country.Should().Be("Germany");
                    org.CountryCode.Should().Be("DE");
                    org.PostalCode.Should().Be("66123");
                    org.Settlement.Should().Be("Fulda");
                }
            }
        }

        [Fact]
        public void KeywordEntityShouldRoundTrip()
        {
            using (var factory = new SqlCompactFactory())
            {
                using (var context = factory.Create())
                {
                    var keyword = new Keyword
                    {
                        Value = "keyword1",
                    };

                    context.Keywords.Add(keyword);
                    context.SaveChanges();
                }

                using (var context = factory.Create())
                {
                    context.Keywords.Should().HaveCount(1);
                    context.Keywords.First().Value.Should().Be("keyword1");
                }
            }
        }
    }
}
