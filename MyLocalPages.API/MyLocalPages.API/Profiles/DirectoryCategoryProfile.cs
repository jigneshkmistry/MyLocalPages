using AutoMapper;
using MyLocalPages.Domain;
using MyLocalPages.DTO;

namespace MyLocalPages.API.Profiles
{
    public class DirectoryCategoryProfile : Profile
    {
        public DirectoryCategoryProfile()
        {
            CreateMap<DirectoryCategory, DirectoryCategoryDTO>();
            CreateMap<DirectoryCategoryForCreationDTO, DirectoryCategory>();
            CreateMap<DirectoryCategoryForUpdateDTO, DirectoryCategory>();
        }
    }
}
