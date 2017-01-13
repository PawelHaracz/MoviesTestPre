
using System.Collections;
using MoviesTestPre.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestPre.BLL.Interfaces
{
    public interface IMarkLogic
    {
        Task<IEnumerable<MarkDto>> GetAll(string userName, bool isAdmin = false);
    }
}