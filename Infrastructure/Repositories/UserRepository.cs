using Application.Interfaces;
using Domain.Modal;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public Task<User?> GetByEmailAsync(string email) =>
        db.Users.Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email == email);
    public Task<Company>GetCompnayBYid(int id) =>
        db.Company.FirstOrDefaultAsync(e => e.Id == id);
    public Task<User?> GetByIdAsync(Guid id) =>
        db.Users.Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == id);

    public Task<User?> GetByRefreshTokenAsync(string token) =>
        db.Users.Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

    public async Task AddAsync(User user) => await db.Users.AddAsync(user);

    public Task UpdateAsync(User user)
    {
        db.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync() => db.SaveChangesAsync();
}