using MyLocalPages.DTO.BusinessCategory;
using MyLocalPages.DTO.BusinessDirectory;

namespace MyLocalPages.API
{
    public class MyLocalPagesDataStore
    {
        //public static MyLocalPagesDataStore Current { get; } = new MyLocalPagesDataStore();
        public List<BusinessDirectoryDTO> BusinessDirectories { get; set; }

        public MyLocalPagesDataStore()
        {
            BusinessDirectories = new List<BusinessDirectoryDTO>()
            {
                new BusinessDirectoryDTO
                {
                    Name = "Accommodation, Travel & Tours",
                    Id = "1",
                    Categories = new List<DirectoryCategoryDTO>()
                    {
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Accommodation Booking & Inquiry Services"
                          },
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Adventure Tours & Holidays Packages"
                          }
                    }
                },
                new BusinessDirectoryDTO
                {
                    Name =  "Animals & Pets",
                    Id = "2",
                    Categories = new List<DirectoryCategoryDTO>()
                    {
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Animal Welfare"
                          },
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Aquaponics"
                          }
                    }
                },
                new BusinessDirectoryDTO
                {
                    Name = "Arts, Crafts & Collectables",
                    Id = "3",
                    Categories = new List<DirectoryCategoryDTO>()
                    {
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Aboriginal Art & Crafts"
                          },
                          new DirectoryCategoryDTO() {
                             Id = "1",
                             Name = "Antiques Auctions & Dealers"
                          }
                    }
                }
            };
        }
    }
}
