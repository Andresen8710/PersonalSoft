using BrowserRentalCar.Domain.Entities;

namespace BrowserRentalCar.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}