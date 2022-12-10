using AutoMapper;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;

namespace MyLocalPages.Services
{
    public class BusinessDirectoryService : ServiceBase<BusinessDirectory, Guid>, IBusinessDirectoryService
    {
        public BusinessDirectoryService(IBusinessDirectoryRepository businessDirectoryRepository,
            ILogger<BusinessDirectoryService> logger, IMapper _mapper) : base(businessDirectoryRepository, logger, _mapper)
        {

        }
    }
}
