// Application/Interfaces/ICompanyService.cs
using Application.DTOs;
using Domain.Modal;

namespace Application.Interfaces
{
    public interface ICompanyService
    {
        Task AddAsync(CompanyDTOs company);
        Task<List<Company>> GetCompanyAsync();
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<Company> DeleteCompanybyidAsync(int id);
        Task UpdateAsync(Company company);

    }
}