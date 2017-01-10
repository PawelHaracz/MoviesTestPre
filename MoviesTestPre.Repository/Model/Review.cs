using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace MoviesTestPre.Repository.Model
{
    public class Review
    {
        public string FilmName { get; set; }
        public Mark Mark { get; set; }
        public string Owner { get; set; }
        public string Comment { get; set; }
    }
}
