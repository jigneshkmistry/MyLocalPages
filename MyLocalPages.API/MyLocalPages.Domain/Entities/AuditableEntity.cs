using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPages.Domain
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
