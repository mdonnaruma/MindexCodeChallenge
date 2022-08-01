using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    internal class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        public Compensation GetById(string employee)
        {
            if (!String.IsNullOrEmpty(employee))
            {
                return _compensationRepository.GetById(employee);
            }

            return null;
        }

        //public Compensation Replace(Compensation originalCompensation, Compensation newCompensation)
        //{
        //    if (originalCompensation != null)
        //    {
        //        _compensationRepository.Remove(originalCompensation);
        //        if (newCompensation != null)
        //        {
        //            // ensure the original has been removed, otherwise EF will complain another entity w/ same employee already exists
        //            _compensationRepository.SaveAsync().Wait();

        //            _compensationRepository.Add(newCompensation);
        //            // overwrite the new employee with previous compensation employee
        //            newCompensation.Employee = originalCompensation.Employee;
        //        }
        //        _compensationRepository.SaveAsync().Wait();
        //    }

        //    return newCompensation;
        //}
    }
}