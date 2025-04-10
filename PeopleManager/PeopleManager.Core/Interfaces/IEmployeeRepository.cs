﻿using PeopleManager.Core.Entities;

namespace PeopleManager.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task SaveAsync(Employee employee);
        Task UpdateAsync(Employee employee);

        Task<Employee> GetByIdAsync(int id);
        Task<IList<Employee>> GetAllAsync();
        Task<IList<Employee>> GetByNameAsync(string name);
        Task<bool> ExistsAsync(int id);
    }
}