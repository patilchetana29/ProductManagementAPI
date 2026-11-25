using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.DTO
{
    public class ProductUpdateDto
    {
        public string ProductName { get; set; } = string.Empty;

        public string? ModifiedBy { get; set; }
    }
}
