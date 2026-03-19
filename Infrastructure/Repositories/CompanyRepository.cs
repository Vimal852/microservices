using Application.Interfaces;
using Domain.Modal;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CompanyRepository(AppDbContext db) : ICompanyRepository
    {
        public async Task AddAsync(Company company) => await db.Company.AddAsync(company);
        


        public Task<Company> deletecompnaybyidAsync(int id)
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

        public Task SaveChangesAsync() => db.SaveChangesAsync();


        public Task UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
