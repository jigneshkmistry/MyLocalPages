using MyLocalPages.DTO.BusinessCategory;

namespace MyLocalPages.DTO.BusinessDirectory
{
    public class BusinessDirectoryDTO
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public int NumberOfCategories
        {
            get
            {
                return Categories.Count;
            }
        }

        public ICollection<DirectoryCategoryDTO> Categories { get; set; } = new List<DirectoryCategoryDTO>();
    }
}
