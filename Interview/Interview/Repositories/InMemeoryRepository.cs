using Interview.Abstract;
using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Repositories
{
    public class InMemeoryRepository : IRepository<Employee, int>
    {
        private List<Employee> _employeesList;

        public InMemeoryRepository()
        {
            _employeesList = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Adam" },
                new Employee { Id = 2, Name = "Bravo" },
                new Employee { Id = 3, Name = "Charlie" },
                new Employee { Id = 4, Name = "David" },
                new Employee { Id = 5, Name = "Elf" }
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeesList.ToList();
        }

        public Employee Get(int id)
        {
            return _employeesList.FirstOrDefault(e => e.Id == id);
        }


        public void Save(Employee item)
        {
            // Check and if exists delete Employee with given id
            Delete(item.Id);
            _employeesList.Add(item);
        }

        public void Delete(int id)
        {
            Employee emp = _employeesList.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _employeesList.Remove(emp);
            }
        }

    }
}
