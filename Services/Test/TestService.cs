using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto.Test;
using Microsoft.AspNetCore.Http;
using Repository.Test;
using TestItem = Models.TestItem;

namespace Services.Test
{
    public class TestService: ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly Random _random = new();
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task AddTests(IEnumerable<Models.Test> tests)
        {
            await _testRepository.AddTestsAsync(tests);
        }

        public async Task<TestDto> GetRandomTest()
        {
            var testsCount = await _testRepository.GetTestsCount();
            var test = await _testRepository.GetTestAsync(_random.Next(1, testsCount+1));
            return _mapper.Map<Models.Test, TestDto>(test);
        }

        public UserAnswersDto Answers(IFormCollection collection)
        {
            var userAnswers = new UserAnswersDto();
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var item = collection[collection.Keys.ElementAt(i)].First().Split(',');
                var item1 = item[0];
                var item2 = item[1];
                userAnswers.Answers.Add((item1, item2));
            }

            return userAnswers;
        }

        public async Task Seed()
        {
            var tests = new List<Models.Test>()
            {
                new()
                {
                    Questions = new List<TestItem>()
                    {
                        new()
                        {
                            Question = "What is your name?",
                            Answer1 = "Paul",
                            Answer2 = "Den",
                            Answer3 = "Pol",
                            CorrectAnswer = "Paul"
                        },
                        new()
                        {
                            Question = "What is your surname?",
                            Answer1 = "Test",
                            Answer2 = "Soup",
                            Answer3 = "Dog",
                            CorrectAnswer = "Dog",
                        },
                        new()
                        {
                            Question = "What is your third name?",
                            Answer1 = "No",
                            Answer2 = "Yes",
                            Answer3 = "Klas",
                            CorrectAnswer = "Yes"
                        }
                    },
                },
                new()
                {
                    Questions = new List<TestItem>()
                    {
                        new()
                        {
                            Question = "What is my name?",
                            Answer1 = "Paul",
                            Answer2 = "Den",
                            Answer3 = "Pol",
                            CorrectAnswer = "Paul"
                        },
                        new()
                        {
                            Question = "What is my surname?",
                            Answer1 = "Test",
                            Answer2 = "Soup",
                            Answer3 = "Dog",
                            CorrectAnswer = "Dog",
                        },
                        new()
                        {
                            Question = "What is my third name?",
                            Answer1 = "No",
                            Answer2 = "Yes",
                            Answer3 = "Klas",
                            CorrectAnswer = "Yes"
                        }
                    },
                },
                new()
                {
                    Questions = new List<TestItem>()
                    {
                        new()
                        {
                            Question = "What is his name?",
                            Answer1 = "Paul",
                            Answer2 = "Den",
                            Answer3 = "Pol",
                            CorrectAnswer = "Paul"
                        },
                        new()
                        {
                            Question = "What is his surname?",
                            Answer1 = "Test",
                            Answer2 = "Soup",
                            Answer3 = "Dog",
                            CorrectAnswer = "Dog",
                        },
                        new()
                        {
                            Question = "What is his third name?",
                            Answer1 = "No",
                            Answer2 = "Yes",
                            Answer3 = "Klas",
                            CorrectAnswer = "Yes"
                        }
                    },
                }
            };

            await AddTests(tests);
        }
    }
}