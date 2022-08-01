using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation GetById(String employee);
        Compensation Create(Compensation compensation);
    }
}