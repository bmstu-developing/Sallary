using System;
using Salary.Domain;
using Salary.Services;

namespace Salary.Data
{
    public class DataGenerator
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Timesheet> _timesheetRepository;
        private readonly IRepository<Sale> _saleRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly PaymentService PaymentService;

        public DataGenerator(IRepository<Employee> employeeRepository, 
            IRepository<Timesheet> timesheetRepository, IRepository<Sale> saleRepository, 
            IRepository<Payment> paymentRepository)
        {
            _employeeRepository = employeeRepository;
            _timesheetRepository = timesheetRepository;
            _saleRepository = saleRepository;
            _paymentRepository = paymentRepository;
            PaymentService = new PaymentService(timesheetRepository, paymentRepository, saleRepository, employeeRepository);
        }

        public void Generate()
        {
            var employee = new Employee("John","575589", 26, new Position(Category.Second, "Saler"));
            _employeeRepository.Add(employee);
            DateTime dateResult;
            DateTime dateResult1;
            DateTime.TryParse("01-12-2014", out dateResult);
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            _saleRepository.Add(new Sale(employee, dateResult, 50000));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 30000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 48000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 4, true));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 25000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 60000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 4, true));

            DateTime.TryParse("01-12-2014", out dateResult);
            DateTime.TryParse("07-12-2014", out dateResult1);
            _paymentRepository.Add(new Payment(employee, dateResult, dateResult, dateResult1, 
                PaymentService.Payroll(employee.Id, dateResult, dateResult1), "Week payment"));

            employee = new Employee("Darry", "394827", 41, new Position(Category.First, "Admin"));
            _employeeRepository.Add(employee);
            DateTime.TryParse("01-12-2014", out dateResult);
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            _saleRepository.Add(new Sale(employee, dateResult, 10000));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 40000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 6, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 31000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 29000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 15000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 6, false));
            DateTime.TryParse("01-12-2014", out dateResult);
            DateTime.TryParse("07-12-2014", out dateResult1);
            _paymentRepository.Add(new Payment(employee, dateResult, dateResult, dateResult1,
                PaymentService.Payroll(employee.Id, dateResult, dateResult1), "Week payment"));

            employee = new Employee("Kate", "480384", 17, new Position(Category.Third, "Saler"));
            _employeeRepository.Add(employee);
            DateTime.TryParse("01-12-2014", out dateResult);
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            _saleRepository.Add(new Sale(employee, dateResult, 50000));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 30000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 4, true));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 48000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 25000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            dateResult = dateResult.AddDays(1);
            _saleRepository.Add(new Sale(employee, dateResult, 60000));
            _timesheetRepository.Add(new Timesheet(employee, dateResult, 8, false));
            DateTime.TryParse("01-12-2014", out dateResult);
            DateTime.TryParse("07-12-2014", out dateResult1);
            _paymentRepository.Add(new Payment(employee, dateResult, dateResult, dateResult1,
                PaymentService.Payroll(employee.Id, dateResult, dateResult1), "Week payment"));

        }
    }
}
