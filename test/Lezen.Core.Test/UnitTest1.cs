using System;
using FluentAssertions;
using Xunit;

namespace Lezen.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            var testSubject = "valid";
            testSubject.Should().Be("valid");
        }
    }
}
