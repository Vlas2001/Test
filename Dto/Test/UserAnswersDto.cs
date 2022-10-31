using System.Collections.Generic;

namespace Dto.Test
{
    public class UserAnswersDto
    {
        public List<(string, string)> Answers { get; set; } = new();
    }
}