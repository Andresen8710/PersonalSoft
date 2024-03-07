using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrowserRentalCar.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly BrowserRentalCarDBContext _context;

        public RepositoryBase(BrowserRentalCarDBContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true)
        {
            //instancio el iqueryable
            IQueryable<T> query = _context.Set<T>();

            //evaluar si el disabletracking esta activo para desactivarlo
            if (disableTracking) query = query.AsNoTracking();

            // validar si estoy entregando un includeString a mi query
            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

            //valida que el predicado sea diferente a nullo
            if (predicate != null) query = query.Where(predicate);

            //valido si el orderby vienen nullo
            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                List<Expression<Func<T, object>>> includes = null,
                                bool disableTracking = true)
        {
            //instancio el iqueryable
            IQueryable<T> query = _context.Set<T>();

            //evaluar si el disabletracking esta activo para desactivarlo
            if (disableTracking) query = query.AsNoTracking();

            //evaluar nuevas entidades
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            //validar si tiene predicado o validacion
            if (predicate != null) query = query.Where(predicate);

            //valido ordenamiento
            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        //procesos en Memoria sin guardar
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}