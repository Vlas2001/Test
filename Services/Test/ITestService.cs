using System.Collections.Generic;
using System.Threading.Tasks;
using Dto.Test;
using Microsoft.AspNetCore.Http;
using Models;

namespace Services.Test
{
    public interface ITestService
    {
        Task AddTests(IEnumerable<Models.Test> tests);

        Task<TestDto> GetRandomTest();

        Task Seed();

        UserAnswersDto Answers(IFormCollection collection);
    }
}