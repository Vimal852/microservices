using Domain.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{

    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByRefreshTokenAsync(string token);
        Task<Company> GetCompnayBYid(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task SaveChangesAsync();

    }
}
