using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesTestPre.WebJob.Interfaces;

namespace MoviesTestPre.Tests.WebJob.Converters.MovieNowPlayingConverter
{
    public class MovieNowPlayingConverterFixure
    {
        public readonly IConverterJson Converter;

        public MovieNowPlayingConverterFixure()
        {
            Converter = new MoviesTestPre.WebJob.Converters.MovieNowPlayingConverter();
        }
    }
}
