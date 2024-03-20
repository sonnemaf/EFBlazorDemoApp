using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace EFBlazorDemoApp.Components
{
    public abstract class DbContextComponentBase<T> : ComponentBase, IDisposable where T : DbContext
    {
        private T? _dbContext;

        [Inject]
        public required IDbContextFactory<T> DatabaseFactory { get; init; }

        public T DatabaseContext => _dbContext ??= DatabaseFactory.CreateDbContext();

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}