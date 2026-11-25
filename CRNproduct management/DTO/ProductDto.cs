using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.DTO
{
   public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}

