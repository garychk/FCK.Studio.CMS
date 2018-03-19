using FCK.Studio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        int Count();
        Task<int> CountAsync();
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(TEntity entity);
        TEntity FirstOrDefault(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllList();
        Task<List<TEntity>> GetAllListAsync();
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TPrimaryKey InsertAndGetId(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        ResultDto<List<TEntity>> GetPageList(int PageIndex, int PageSize);
        ResultDto<List<TEntity>> GetPageList(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> predicate);
        Task<ResultDto<List<TEntity>>> GetPageListAsync(int PageIndex, int PageSize);
        Task<ResultDto<List<TEntity>>> GetPageListAsync(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> predicate);
    }
}
