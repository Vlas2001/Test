using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repository.Test
{
    public interface ITestRepository
    {

        Task AddTestsAsync(IEnumerable<Models.Test> test);

        Task<Models.Test> GetTestAsync(int id);

        Task<int> GetTestsCount();
    }
}