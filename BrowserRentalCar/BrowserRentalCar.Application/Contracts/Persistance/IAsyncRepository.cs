using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BrowserRentalCar.Domain.Entities;

namespace BrowserRentalCar.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>> predicate);//se pasa la condicion logica con expresion functions, esto se tranforma en SQL
        
        //ordenamiento
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);

        //paginacion
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                List<Expression<Func<T, object>>> includes = null,
                                bool disableTracking = true);

        //registro por Id
        Task<T> GetByIdAsync(Guid id);

        //insertar Registros
        Task<T> AddAsync(T entity);

        // actualizar registros
        Task<T> UpdateAsync(T entity);

        //Eliminar 
        Task DeleteAsync(T entity);

        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
