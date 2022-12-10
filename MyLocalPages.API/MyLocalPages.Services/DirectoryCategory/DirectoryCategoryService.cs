using AutoMapper;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;

namespace MyLocalPages.Services
{
    public class DirectoryCategoryService : ServiceBase<DirectoryCategory, Guid>, IDirectoryCategoryService
    {
        public DirectoryCategoryService(IDirectoryCategoryRepository directoryCategoryRepository,
            ILogger<DirectoryCategoryService> logger, IMapper _mapper) : base(directoryCategoryRepository, logger, _mapper)
        {

        }
    }
}
