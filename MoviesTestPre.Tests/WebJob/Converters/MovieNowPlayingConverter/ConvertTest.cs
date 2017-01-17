using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using MoviesTestPre.SetMovies.Interfaces;
using MoviesTestPre.Tests.ExampleData;
using Newtonsoft.Json.Linq;
using Xunit;

namespace MoviesTestPre.Tests.WebJob.Converters.MovieNowPlayingConverter
{
    public class ConvertTest : IClassFixture<MovieNowPlayingConverterFixure>
    {
        private readonly IConverterJson _converter;

        public ConvertTest(MovieNowPlayingConverterFixure fixure)
        {
            _converter = fixure.Converter;
        }

        [Fact]
        public void Add_Example_Json_Should_Return_Only_Titles()
        {
            var fake = new FakeJsonMovie();
            var expectation = fake.ConvertedJson();
            var json = fake.JsonResponse();

            var act = _converter.Convert(json);

            act.ShouldAllBeEquivalentTo(expectation);
        }

        [Fact]
        public void Add_Null_Should_Throw_RuntimeBinderException()
        {
            dynamic json = null;

            Action act = () => _converter.Convert(json);

            act.ShouldThrow<RuntimeBinderException>();
        }

        [Fact]
        public void Add_Empty_Json_Should_Return_Throw_NullReferenceException()
        {
            var json = new JObject();

            Action act = () => _converter.Convert(json);

            act.ShouldThrow<NullReferenceException>().Which.Message.Should().Be("Results is null");
        }

        [Fact]
        public void Add_Json_With_Empty_Results_Empty_IEnumerable()
        {
            var json = new JObject(new JProperty("results", new JArray())); ;
            IEnumerable<string> expectation = new List<string>();

            var act = _converter.Convert(json);

            act.ShouldAllBeEquivalentTo(expectation);
        }


    }
}
