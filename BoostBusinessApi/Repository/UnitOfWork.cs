using BoostBusinessApi.Data;
using BoostBusinessApi.Repository.Interface;

namespace BoostBusinessApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBContext _context;
        public UnitOfWork(DBContext context)
        {
            this._context = context;
        }

        #region Repository

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        #endregion


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            Dispose();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
