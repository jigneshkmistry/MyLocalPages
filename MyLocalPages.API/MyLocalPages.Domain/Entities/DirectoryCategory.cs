using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPages.Domain.Entities
{
    public class DirectoryCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
       
        public Guid BusinessDirectoryId { get; set; }

        [ForeignKey("BusinessDirectoryId")]
        public BusinessDirectory? BusinessDirectory { get; set; }
    }
}
