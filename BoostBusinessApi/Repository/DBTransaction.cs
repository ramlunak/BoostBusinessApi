using BoostBusinessApi.Data;
using BoostBusinessApi.Repository.Interface;

namespace BoostBusinessApi.Repository
{
    public class DBTransaction : IDBTransaction
    {

        private readonly DBContext _context;
        public DBTransaction(DBContext context)
        {
            this._context = context;
        }

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
