using System;
using System.Threading.Tasks;
using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetById(String employee);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}