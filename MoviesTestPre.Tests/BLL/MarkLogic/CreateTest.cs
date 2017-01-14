using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesTestPre.BLL.Interfaces;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MarkLogic
{
    public class CreateTest : IClassFixture<MarkLogicFixure>
    {
        private readonly IMarkLogic _logic;

        public CreateTest(IMarkLogic logic)
        {
            _logic = logic;
        }

        [Fact]
        public async Task TODO()
        {
            throw new NotImplementedException();
        }
    }
}
