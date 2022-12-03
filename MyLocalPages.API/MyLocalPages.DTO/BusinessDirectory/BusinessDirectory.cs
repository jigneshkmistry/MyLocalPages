using MyLocalPages.DTO.BusinessCategory;

namespace MyLocalPages.DTO.BusinessDirectory
{
    public class BusinessDirectoryDTO
    {
        /// <summary>
        /// Business Directory Id
        /// </summary>
        public string Id { get; set; } = "";

        /// <summary>
        /// Business Directory Name
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Number of business directory category
        /// </summary>
        public int NumberOfCategories
        {
            get
            {
                return Categories.Count;
            }
        }

        /// <summary>
        /// Business Directory Category
        /// </summary>
        public ICollection<DirectoryCategoryDTO> Categories { get; set; }
          = new List<DirectoryCategoryDTO>();
    }
}
