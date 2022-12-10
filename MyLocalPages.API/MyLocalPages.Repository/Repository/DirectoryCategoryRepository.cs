using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;

namespace MyLocalPages.Repository
{
    public class DirectoryCategoryRepository : Repository<DirectoryCategory, Guid>, IDirectoryCategoryRepository
    {
        #region PRIVATE VARIABLE

        private readonly DbSet<DirectoryCategory> _dbset;
        private readonly MyLocalPagesContext _context;

        #endregion

        #region CONSTRUCTOR

        public DirectoryCategoryRepository(MyLocalPagesContext context, ILogger<DirectoryCategoryRepository> logger) : base(context, logger)
        {
            _context = context;
            _dbset = _context.Set<DirectoryCategory>();
        }

        #endregion

        #region OVERRIDDEN IMPLEMENTATION

        public override string GetPrimaryKeyColumnName()
        {
            return "Id";
        }

        public override IQueryable<DirectoryCategory> GetFilteredEntities(bool bIsAsTrackable = false)
        {
            return _dbset;
        }

        #endregion

    }
}
