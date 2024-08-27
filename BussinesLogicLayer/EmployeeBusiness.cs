using EntityLayer;
using EntityLayer.Repository;
using EntityLayer.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    internal class EmployeeBusiness : IEmployeeBusiness
    {

        private readonly AbstractDapperRepository _employeeRepository;


        public EmployeeBusiness(AbstractDapperRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



            public void UpdateEmployee(Employee employee)
        {
            if (employee.Id <= 0)
            {
                throw new ArgumentException("Employee ID is invalid.");
            }

            var updateQuery = QueryWarehouse.Employee.Update;

            _employeeRepository.Update(updateQuery, employee);
        }
    }
}
