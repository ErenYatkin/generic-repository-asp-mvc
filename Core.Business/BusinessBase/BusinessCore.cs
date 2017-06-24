using Core.Contract;
using Core.Model.Context;
using Core.Repository.RepositoryBase;

namespace Core.Business.BusinessBase
{
    /// <summary>
    /// Stores Generic Repository instance and BaseDbContext instance.
    /// Also allows you to create transaction scopes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessCore<T> : Service<T> where T: Entity.Entity
    {
        public BaseRepository<T> Repository { get; set; }
        public BaseDbContext _context { get; set; }
    }
}
