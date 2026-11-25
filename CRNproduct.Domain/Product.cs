using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct.Domain
{
    public class Product
    {
      
            public int Id { get; set; }

            public string ProductName { get; set; } = string.Empty;

            public string? CreatedBy { get; set; }

            public DateTime CreatedOn { get; set; }

            public string? ModifiedBy { get; set; }

            public DateTime? ModifiedOn { get; set; }
        }
    }

