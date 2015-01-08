using System;
using Salary.Domain;

namespace Salary.Api
{
    public class SalaryApi
    {
        #region Repositories
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Sale> _saleRepository;
        private readonly IRepository<Position> _positionRepository;
        private readonly IRepository<Timesheet> _timesheetRepository;
        private readonly IRepository<Award> _awardRepository;
        #endregion

        #region Constructor
        public SalaryApi(
            IRepository<Employee> employeeRepository, 
            IRepository<Payment> paymentRepository, 
            IRepository<Sale> saleRepository, 
            IRepository<Position> positionRepository, 
            IRepository<Timesheet> timesheetRepository, 
            IRepository<Award> awardRepository)
        {
            if (employeeRepository == null) throw  new ArgumentNullException("employeeRepository");
            if (paymentRepository == null) throw  new ArgumentNullException("paymentRepository");
            if (saleRepository == null) throw  new ArgumentNullException("saleRepository");
            if (positionRepository == null) throw  new ArgumentNullException("positionRepository");
            if (timesheetRepository == null) throw  new ArgumentNullException("timesheetRepository");
            if (awardRepository == null) throw  new ArgumentNullException("awardRepository");
            _employeeRepository = employeeRepository;
            _paymentRepository = paymentRepository;
            _saleRepository = saleRepository;
            _positionRepository = positionRepository;
            _timesheetRepository = timesheetRepository;
            _awardRepository = awardRepository;
        }

        #endregion
    }
}
