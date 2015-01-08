using System;
using System.Collections.Generic;
using System.Linq;
using Salary.Domain;

namespace Salary.Services
{
    public class PaymentService
    {
        
        
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Timesheet> _timesheetRepository;
        private readonly IRepository<Sale> _saleRepository;
        private readonly IRepository<Employee> _employeesRepository;

        public PaymentService(IRepository<Timesheet> timesheetRepository, 
            IRepository<Payment> paymentRepository, IRepository<Sale> saleRepository, IRepository<Employee> employeesRepository)
        {
            _paymentRepository = paymentRepository;
            _timesheetRepository = timesheetRepository;
            _saleRepository = saleRepository;
            _employeesRepository = employeesRepository;
        }

        private Employee GetEmployeeById(Guid employeeId)
        {
            return _employeesRepository.Get(employeeId);
        }

        public void AddPayment(Guid employeeId, DateTime date, DateTime dateFrom, 
            DateTime dateTo, decimal summ, string info)
        {
            _paymentRepository.Add(new Payment(GetEmployeeById(employeeId), date, dateFrom, dateTo, summ, info));
        }

        public List<Payment> GetListByEmployeeId(Guid employeeId)
        {
            return _paymentRepository.AsQueryable()
                .Where(p => p.Employee.Id == employeeId)
                .ToList();
        }

        public decimal Payroll(Guid employeeId, DateTime dateFrom, DateTime dateTo)
        {
            var workedtime = GetWorkedHours(employeeId, dateFrom, dateTo);
            var sales = GetSaleForPeriod(employeeId, dateFrom, dateTo);
            return workedtime.GetPaymentForHours(GetEmployeeById(employeeId).Rate) + sales * GetEmployeeById(employeeId).Position.Percent;
        }

        public WorkedHours GetWorkedHours(Guid employeeId, DateTime dateFrom, DateTime dateTo)
        {
            return new WorkedHours(_timesheetRepository.AsQueryable()
                .Where(t => t.Employee.Id == employeeId
                            && !t.OverWork
                            && t.Date.Date >= dateFrom.Date
                            && t.Date.Date <= dateTo.Date)
                .Sum(t => t.Hours),
                _timesheetRepository.AsQueryable()
                    .Where(t => t.Employee.Id == employeeId
                                && t.OverWork
                                && t.Date.Date >= dateFrom.Date
                                && t.Date.Date <= dateTo.Date)
                    .Sum(t => t.Hours));
        }

        private decimal GetSaleForPeriod(Guid employeeId, DateTime dateFrom, DateTime dateTo)
        {
            return _saleRepository.AsQueryable()
                .Where(s => s.Employee.Id == employeeId
                    && s.Date >= dateFrom
                    && s.Date <= dateTo)
                .Sum(s => s.Summ);
        }
    }
}
