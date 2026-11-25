using CRNproduct.Domain;
using CRNproduct_management.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct.Infrastructure.Repository
{
    public class UserRepo : IUser
    {
        private readonly ApplicationDbcontext _dbcontext;

        public UserRepo( ApplicationDbcontext  dbcontext){
            _dbcontext = dbcontext;

        }

        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            _dbcontext.RefreshTokens.Add(refreshToken);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbcontext.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return await _dbcontext.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task<User> RegisterAsync(User user)
        {

            _dbcontext.User.Add(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task UpdateRefreshTokenAsync(RefreshToken refreshToken)
       
        {
            _dbcontext.RefreshTokens.Update(refreshToken);
            await _dbcontext.SaveChangesAsync();
        }
    }
    }
