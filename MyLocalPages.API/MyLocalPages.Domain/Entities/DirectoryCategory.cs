using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyLocalPages.Domain
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
