using System;
using System.Collections.Generic;
using Interview.Models;
using Interview.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.InMemoryRepository
{
    [TestClass]
    public class InMemeoryRepositoryTests
    {
        [TestMethod]
        public void Test_InMemoryRepo_WhenInit_IsNotNull()
        {
            // Arrange
            InMemeoryRepository repository = new InMemeoryRepository();
            // Act
            IEnumerable<Employee> expected = repository.GetAll();
            // Assert
            Assert.IsNotNull(expected, "In memory repo has initiliased and is not null");
        }

        [TestMethod]
        public void Test_InMemoryRepo_WhenGetAll_Return5Records()
        {
            // Arrange
            InMemeoryRepository repository = new InMemeoryRepository();
            // Act
            IEnumerable<Employee> expected = repository.GetAll();
            // Assert
            Assert.AreEqual(5, expected.Count());
        }

        [TestMethod]
        public void Test_InMemoryRepo_WhenGetById_ReturnEmployee()
        {
            // Arrange
            InMemeoryRepository repository = new InMemeoryRepository();
            // Act
            Employee expected = repository.Get(1);
            // Assert
            Assert.IsTrue(expected.Id == 1 && expected.Name == "Adam");
        }

        [TestMethod]
        public void Test_InMemoryRepo_WhenAdd_CheckNewEmployeeExixts()
        {
            // Arrange
            InMemeoryRepository repository = new InMemeoryRepository();
            Employee newEmployee = new Employee { Id = 6, Name = "Freddy" };
            // Act
            repository.Save(newEmployee);
            IEnumerable<Employee> expected = repository.GetAll();
            // Assert
            Assert.IsTrue(expected.Any(e => e.Id == newEmployee.Id && e.Name == newEmployee.Name));
        }

        [TestMethod]
        public void Test_InMemoryRepo_WhenDelete_CheckDeletedEmployeeDoesNotExixts()
        {
            // Arrange
            InMemeoryRepository repository = new InMemeoryRepository();
            // Act
            repository.Delete(6);
            IEnumerable<Employee> expected = repository.GetAll();
            // Assert
            Assert.IsFalse(expected.Any(e => e.Id == 6 && e.Name == "Freddy"));
        }
    }
}
