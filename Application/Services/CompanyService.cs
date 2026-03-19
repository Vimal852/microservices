using Application.DTOs;
using Application.Interfaces;
using Domain.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CompanyService(ICompanyRepository repo) : ICompanyService  
    {
        public async Task AddAsync(CompanyDTOs company)
        {
            var newCompany = new Company   
            {
                CompanyName = company.CompanyName,
                Email = company.Email,
                PhoneNumber = company.PhoneNumber,
                Website = company.Website,
                City = company.City,
                Country = company.Country,
            };
            await repo.AddAsync(newCompany);
            await repo.SaveChangesAsync();
        }

        public Task<Company> DeleteCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // baki methods bhi yahan implement kar...


        public Task<Company> deletecompnaybyidAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetCompnayAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetCompnaybyidAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
