﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Repositories
{
    internal class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        //public CompensationRespository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        //{
        //    _compensationContext = compensationContext;
        //    _logger = logger;
        //}

        public Compensation Add(Compensation compensation)
        {
            compensation.Employee = Guid.NewGuid().ToString();
            _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetById(string id)
        {
            return _compensationContext.Compensations.SingleOrDefault(e => e.Employee == id);
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }

    }
}