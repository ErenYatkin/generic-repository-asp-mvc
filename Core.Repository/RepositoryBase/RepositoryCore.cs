using Core.Contract;
using Core.Model.Context;

namespace Core.Repository.RepositoryBase
{
    public class RepositoryCore<T> : Service<T> where T : Entity.Entity
    {
        public BaseDbContext _context { get; set; }
    }
}
