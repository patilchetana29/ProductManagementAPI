using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.DTO
{
   public class LoginResponseDTo
    {
        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;
    }
}
