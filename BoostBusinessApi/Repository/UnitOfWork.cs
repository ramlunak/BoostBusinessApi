using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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


        private ISystemErroRepository _systemErroRepository;
        public ISystemErroRepository SystemErroRepository
        {
            get
            {

                if (this._systemErroRepository == null)
                {
                    this._systemErroRepository = new SystemErroRepository(_context);
                }
                return _systemErroRepository;
            }
        }

        #endregion

        public async Task Commit()
        {            
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            this._context.ChangeTracker.Clear();
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
