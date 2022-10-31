using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository.Test
{
    public class TestRepository: ITestRepository
    {
        private readonly TestContext _context;

        public TestRepository(TestContext context)
        {
            _context = context;
        }

        public async Task AddTestsAsync(IEnumerable<Models.Test> tests)
        {
            await _context.AddRangeAsync(tests);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Test> GetTestAsync(int id)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(item => item.Id == id);
            test!.Questions = await _context.TestItems.Where(item => item.TestId == test.Id).ToListAsync();
            return test;
        }

        public async Task<int> GetTestsCount()
        {
            return await _context.Tests.CountAsync();
        }
    }
}