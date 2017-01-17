using System;
using System.Collections.Generic;
using MoviesTestPre.SetMovies.Interfaces;

namespace MoviesTestPre.SetMovies.Converters
{
    public class MovieNowPlayingConverter : IConverterJson
    {
        public IEnumerable<string> Convert(dynamic json)
        {

            if(json.results == null) throw new NullReferenceException("Results is null");
            var response = GetNames(json.results);            

            return response;
        }

        private IEnumerable<string> GetNames(dynamic collection)
        {
            foreach (var obj in collection)
            {
                yield return obj.title;
            }

        }

    }
}
