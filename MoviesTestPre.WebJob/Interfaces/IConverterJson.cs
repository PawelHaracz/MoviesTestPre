using System.Collections.Generic;

namespace MoviesTestPre.WebJob.Interfaces
{
    public interface IConverterJson
    {
        IEnumerable<string> Convert(dynamic json);
    }
}