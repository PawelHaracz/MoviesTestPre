
using System.Collections;
using MoviesTestPre.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestPre.BLL.Interfaces
{
    public interface IMarkLogic
    {
        Task<IEnumerable<MarkDto>> GetAll(string userName, bool isAdmin = false);
        Task<int> Create(MarkDto model);
        Task<MarkDto> Get(int id);
        Task<int> Update(MarkDto model);
    }
}