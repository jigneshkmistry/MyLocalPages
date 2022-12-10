using AutoMapper;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;
using MyLocalPages.DTO;

namespace MyLocalPages.API.Profiles
{
    public class BusinessDirectoryProfile : Profile
    {
        public BusinessDirectoryProfile()
        {
            CreateMap<BusinessDirectory, BusinessDirectoryDTO>();
            CreateMap<BusinessDirectoryForCreationDTO, BusinessDirectory>();
            CreateMap<BusinessDirectoryForUpdateDTO, BusinessDirectory>();
        }
    }
}
