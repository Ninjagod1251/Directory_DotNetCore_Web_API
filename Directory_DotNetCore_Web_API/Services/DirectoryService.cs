using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Directory_DotNetCore_Web_API.Models;
using Microsoft.Extensions.Configuration;

namespace Directory_DotNetCore_Web_API.Services
{
    public class DirectoryService
    {
        private readonly IMongoCollection<EmployeeModel> _employees;

        public DirectoryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DirectoryDb"));
            var database = client.GetDatabase("DirectoryDb");
            _employees = database.GetCollection<EmployeeModel>("employees");
        }

        public List<EmployeeModel> Get()
        {
            return _employees.Find(EmployeeModel => true).ToList();
        }

        public EmployeeModel Get(string id)
        {
            return _employees.Find<EmployeeModel>(employee => employee.Id == id).FirstOrDefault();
        }

        public EmployeeModel Create(EmployeeModel employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }

        public void Update(string id, EmployeeModel employeeIn)
        {
            _employees.ReplaceOne(employee => employee.Id == id, employeeIn);
        }

        public void Remove(EmployeeModel employeeIn)
        {
            _employees.DeleteOne(employee=> employee.Id == employeeIn.Id);
        }

        public void Remove(string id)
        {
            _employees.DeleteOne(employee => employee.Id == id);
        }

    }
}
