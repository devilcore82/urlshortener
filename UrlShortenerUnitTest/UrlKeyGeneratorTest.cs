using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Services;
using Xunit;

namespace UrlShortenerUnitTest
{
    public class UrlKeyGeneratorTest
    {
        private const int ExpectedKeyLength = 7;

        [Fact]
        public void WhenGenerateAKeyOneTime_ThenRandomKeyIsGenerated()
        {
            var generator = new UrlKeyGenerator();
            var key =  generator.Generate();

            key.Length.Should().Be(ExpectedKeyLength);
        }

        [Fact]
        public void WhenGenerateAKeyMultipleTimes_ThenRandomKeyIsGenerated()
        {
            var generator = new UrlKeyGenerator();
            var keyList = new List<string>();

            for(int i=0;i< 1000000;i++)
            {
                var key = generator.Generate();
                keyList.Should().NotContain(key);
                keyList.Add(key);
            }
        }

    }
}
