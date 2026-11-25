using CRNproduct.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Interface
{
   public interface IUser
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User> RegisterAsync(User user);
        Task AddRefreshTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetRefreshTokenAsync(string token);

        Task UpdateRefreshTokenAsync(RefreshToken refreshToken);
    }
}
