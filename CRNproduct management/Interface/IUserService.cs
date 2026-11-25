using CRNproduct.Domain;
using CRNproduct_management.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Interface
{
   public interface IUserService
    {
        Task<User> RegisterAsync(UserCreateDto dto);

        Task<LoginResponseDTo?> LoginAsync(LoginDto dto);

        Task<LoginResponseDTo?> RefreshTokenAsync(RefreshTokenRequDto dto);
    }
}
