using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Repositories;
using API.Models;
using API.Services.Infrastructure;

namespace API.Services
{
    public class QuizService : ServiceBase<Quiz>, IQuizService
    {
        public QuizService(IQuizRepository repository) : base(repository)
        {

        }
    }
}
