using Domain.Modal;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompanyAsync();
    Task<Company?> GetCompanyByIdAsync(int id);
    Task<Company> DeleteCompanybyidAsync(int id);
    Task AddAsync(Company company); 
    Task UpdateAsync(Company company);
    Task SaveChangesAsync();
}