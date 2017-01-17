using System.Collections.Generic;

namespace MoviesTestPre.SetMovies.Interfaces
{
    public interface IConverterJson
    {
        IEnumerable<string> Convert(dynamic json);
    }
}