using System;
using System.Collections.Generic;
using System.Linq;
using Salary.Domain;

namespace Salary.Services
{
    public class SaleService
    {
        private readonly IRepository<Sale> _saleRepository;

        public SaleService(IRepository<Sale> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public void AddSale(Employee employee, DateTime date, decimal summ)
        {
            _saleRepository.Add(new Sale(employee, date, summ));
        }
    }
}
