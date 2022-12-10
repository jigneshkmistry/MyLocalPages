using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;

namespace MyLocalPages.Repository
{
    public class BusinessDirectoryRepository : Repository<BusinessDirectory, Guid>, IBusinessDirectoryRepository
    {
        #region PRIVATE VARIABLE

        private readonly DbSet<BusinessDirectory> _dbset;
        private readonly MyLocalPagesContext _context;

        #endregion

        #region CONSTRUCTOR

        public BusinessDirectoryRepository(MyLocalPagesContext context, ILogger<BusinessDirectoryRepository> logger) : base(context, logger)
        {
            _context = context;
            _dbset = _context.Set<BusinessDirectory>();
        }

        #endregion

        #region OVERRIDDEN IMPLEMENTATION

        public override string GetPrimaryKeyColumnName()
        {
            return "Id";
        }

        public override IQueryable<BusinessDirectory> GetFilteredEntities(bool bIsAsTrackable = false)
        {
            return _dbset;
        }

        #endregion

    }
}
