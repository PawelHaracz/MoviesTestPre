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
            Expression<Func<Mark, bool>> expression;

            if (isAdmin == false)
                expression = m => m.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase);
            else
                expression = m => true;

           var marks =  await _repository.Get(expression);

            return Mapper.Map<IEnumerable<MarkDto>>(marks);
        }

        public async Task<int> Create(MarkDto model)
        {
            var mark = Mapper.Map<Mark>(model);

            var id = await _repository.Add(mark);

            return id;
        }

        public async Task<MarkDto> Get(int id)
        {
            var mark = await _repository.Find(id);

            return Mapper.Map<MarkDto>(mark);
        }

        public async Task<int> Update(MarkDto model)
        {
            var mark = Mapper.Map<Mark>(model);
            var id = await _repository.Edit(mark);
            return id;
        }
    }
}