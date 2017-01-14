using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;
using MoviesTestPre.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesTestPre.BLL
{
    public class MarkLogic : LogicBase, IMarkLogic
    {
        private readonly IRepository<Mark> _repository;

        public MarkLogic(IMapper mapper, IRepository<Mark> repository)
            :base(mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MarkDto>> GetAll(string userName, bool isAdmin = false)
        {
            Expression<Func<Mark, bool>> @predicate;

            if (isAdmin == false)
                @predicate = m => m.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase);
            else
                @predicate = m => true;

           var marks =  await _repository.Get(@predicate);

            return Mapper.Map<IEnumerable<MarkDto>>(marks);
        }

        public Task Create(MarkDto model)
        {
            throw new NotImplementedException();
        }
    }
}