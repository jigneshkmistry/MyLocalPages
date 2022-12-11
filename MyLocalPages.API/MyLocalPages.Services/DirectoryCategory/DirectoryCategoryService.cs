using AutoMapper;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;
using MyLocalPages.DTO;

namespace MyLocalPages.Services
{
    public class DirectoryCategoryService : ServiceBase<DirectoryCategory, Guid>, IDirectoryCategoryService
    {

        #region PRIVATE MEMBERS

        private readonly IDirectoryCategoryRepository _directoryCategoryRepository;

        #endregion

        #region CONSTRUCTOR

        public DirectoryCategoryService(IDirectoryCategoryRepository directoryCategoryRepository,
            ILogger<DirectoryCategoryService> logger, IMapper _mapper) : base(directoryCategoryRepository, logger, _mapper)
        {

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
