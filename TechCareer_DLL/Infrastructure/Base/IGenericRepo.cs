using Microsoft.EntityFrameworkCore;
using TechCareer_DLL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Base
{
    public interface IGenericRepo<T>where T:class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate, string? includeProperties);
        //IEnumerable<T> GetAllbyParent(Expression<Func<T, bool>> predicate);
        T GetT(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Add(List<T> entity);
        void Delete(T entity);
        Task DeletebyID(int id);
        void DeleteRange(IEnumerable<T> entitylist);
        Task Update(T entity);
    }
    public class GenericRepo<T> : IGenericRepo<T>where T:class
    {
        private readonly JobContext _context;
        private DbSet<T> _dbset;


        public GenericRepo(JobContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();

        }
        public virtual async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        public async Task Add(List<T> entity)
        {
            await _dbset.AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task DeletebyID(int id)
        {
            var entity = _dbset.Find(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
            }
        }
        public void DeleteRange(IEnumerable<T> entitylist)
        {
            _dbset.RemoveRange(entitylist);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate,
            string? includeProperties)
        {
            IQueryable<T> query = _dbset;
            try
            {
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties != null)
                {
                    foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbset.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            //_context.Entry(entity).State = EntityState.Detached;
        }

    }
}
