using AutoMapper;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;
using MyLocalPages.DTO;

namespace MyLocalPages.Services
{
    public class BusinessDirectoryService : ServiceBase<BusinessDirectory, Guid>, IBusinessDirectoryService
    {

        #region PRIVATE MEMBERS

        private readonly IBusinessDirectoryRepository _businessDirectoryRepository;
       
        #endregion

        #region CONSTRUCTOR

        public BusinessDirectoryService(IBusinessDirectoryRepository businessDirectoryRepository,
            IMapper mapper, ILogger<BusinessDirectoryService> logger, IMapper _mapper) : base(businessDirectoryRepository, logger, _mapper)
        {                     
            _businessDirectoryRepository = businessDirectoryRepository;
        }

        #endregion

        #region PUBLIC MEMBERS   


        #endregion

        #region OVERRIDDEN IMPLEMENTATION

        public override Dictionary<string, PropertyMappingValue> GetPropertyMapping()
        {
            return new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "Id", new PropertyMappingValue(new List<string>() { "Id" })},
                        { "Name", new PropertyMappingValue(new List<string>() { "Name" })},
                        { "UpdatedOn", new PropertyMappingValue(new List<string>() { "UpdatedOn" })}
                    };
        }

        public override string GetDefaultOrderByColumn()
        {
            return "UpdatedOn";
        }

        public override string GetDefaultFieldsToSelect()
        {
            return "Id,Name";
        }

        #endregion
   
    }
}
