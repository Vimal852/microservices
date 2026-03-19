using Domain.Modal;

public interface ICompanyRepository
{
    Task<Company?> GetCompnayAsync();
    Task<Company?> GetCompnaybyidAsync(int id);
    Task<Company> deletecompnaybyidAsync(int id);
    Task AddAsync(Company company); 
    Task UpdateAsync(Company company);
    Task SaveChangesAsync();
}