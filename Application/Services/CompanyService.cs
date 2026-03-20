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

        public async Task<Company> DeleteCompanybyidAsync(int id)
        {

           await repo.DeleteCompanybyidAsync(id);
                await repo.SaveChangesAsync();
                return new Company();
        }



        public async Task<List<Company>> GetCompanyAsync()
        {
            return await repo.GetCompanyAsync();
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {
            await repo.GetCompanyByIdAsync(id);
            return new Company();
        }

  

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Company company)
        {
            await repo.UpdateAsync(company);
                await repo.SaveChangesAsync();
        }
    }
}
