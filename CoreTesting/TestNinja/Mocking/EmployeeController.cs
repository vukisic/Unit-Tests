﻿using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeRemover _remover;

        public EmployeeController(IEmployeeRemover employeeRemover =null)
        {
            _remover = employeeRemover ?? new EmployeeRemover();
        }

        public ActionResult DeleteEmployee(int id)
        {
            _remover.RemoveEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}