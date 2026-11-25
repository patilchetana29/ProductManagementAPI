using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.DTO
{
 public class ProductCreateDto
    {
        public string ProductName { get; set; } = string.Empty;

        public string? CreatedBy { get; set; }
    }
}
