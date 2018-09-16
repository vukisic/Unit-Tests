using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class EmployeeRemover : IEmployeeRemover
    {
        private EmployeeContext _db;
        public EmployeeRemover()
        {
            _db = new EmployeeContext();
        }
        public void RemoveEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
