using Application.Interfaces;
using Domain.Modal;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
        


        public async Task<Company> DeleteCompanybyidAsync(int id)
        {
            var company = await db.Company.FindAsync(id);

            if (company == null)
            {
                return null; 
            }

            db.Company.Remove(company);
            await db.SaveChangesAsync();

            return company;
        }


        public async Task<List<Company>> GetCompanyAsync()
        {
            return await db.Company.ToListAsync();
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {
            return await db.Company.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task SaveChangesAsync() => db.SaveChangesAsync();


        public Task UpdateAsync(Company company)
        {
            db.Company.Update(company);
            return Task.CompletedTask;
        }
    }
}
