using System.ComponentModel.DataAnnotations;

namespace MyLocalPages.DTO
{
    public class DirectoryCategoryForUpdateDTO
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}
