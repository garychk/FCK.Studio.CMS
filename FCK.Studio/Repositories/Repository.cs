using FCK.Studio.Dto;
using FCK.Studio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FCK.Studio.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private DbContext dbContext { get; set; }
        private IDbSet<TEntity> dbEntity { get; set; }
        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            dbEntity = dbContext.Set<TEntity>();
        }

        ~Repository()
        {
            dbContext.Dispose();
        }

        public int Count()
        {
            return dbEntity.ToList().Count;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return dbEntity.Where<TEntity>(predicate).Count<TEntity>();
        }

        public async Task<int> CountAsync()
        {
            var result = await GetAllListAsync();
            return result.Count;
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return Count(predicate);
            });
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = Get(id);
            dbContext.Entry(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await Task.Run(() =>
            {
                Delete(id);
            });
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                Delete(entity);
            });
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            var model = dbEntity.FirstOrDefault(CreateEqualityExpressionForId(id));
            return model;
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await dbEntity.FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public TEntity Get(TPrimaryKey id)
        {
            return FirstOrDefault(id);
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await Task.Run(() =>
            {
                return FirstOrDefaultAsync(id);
            });
        }
        public IQueryable<TEntity> GetAll()
        {
            var lists = dbEntity.ToList().AsQueryable();
            return lists;
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var lists = dbEntity.Where(predicate).ToList().AsQueryable();
            return lists;
        }
        public List<TEntity> GetAllList()
        {
            var lists = dbEntity.ToList();
            return lists;
        }
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            var lists = dbEntity.Where(predicate).ToList();
            return lists;
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await dbEntity.ToListAsync();
        }
        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return GetAllList(predicate);
            });
        }

        public TEntity Insert(TEntity entity)
        {
            dbEntity.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return Insert(entity);
            });
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            dbEntity.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return InsertAndGetId(entity);
            });
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            if (entity.Id.Equals(0))
            {
                return Insert(entity);
            }
            else
            {
                return Update(entity);
            }
        }

        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return InsertOrUpdate(entity);
            });
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            if (entity.Id.Equals(0))
            {
                Insert(entity);
                return entity.Id;
            }
            else
            {
                Update(entity);
                return entity.Id;
            }
        }

        public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return InsertOrUpdateAndGetId(entity);
            });
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return Update(entity);
            });
        }
        public ResultDto<List<TEntity>> GetPageList(int PageIndex, int PageSize)
        {
            ResultDto<List<TEntity>> result = new ResultDto<List<TEntity>>();
            var lists = GetAllList();
            result.total = lists.Count;
            if (PageSize > 0)
            {
                result.pages = (result.total + PageSize - 1) / PageSize;
                lists = lists.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
            }
            result.datas = lists;
            return result;
        }
        public ResultDto<List<TEntity>> GetPageList(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> predicate)
        {
            ResultDto<List<TEntity>> result = new ResultDto<List<TEntity>>();
            var lists = GetAllList(predicate);
            result.total = lists.Count;
            if (PageSize > 0)
            {
                result.pages = (result.total + PageSize - 1) / PageSize;
                lists = lists.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
            }
            result.datas = lists;
            return result;
        }
        public async Task<ResultDto<List<TEntity>>> GetPageListAsync(int PageIndex, int PageSize)
        {
            ResultDto<List<TEntity>> result = new ResultDto<List<TEntity>>();
            var lists = await GetAllListAsync();
            result.total = lists.Count;
            if (PageSize > 0)
            {
                result.pages = (result.total + PageSize - 1) / PageSize;
                lists = lists.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
            }
            result.datas = lists;
            return result;
        }
        public async Task<ResultDto<List<TEntity>>> GetPageListAsync(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> predicate)
        {
            ResultDto<List<TEntity>> result = new ResultDto<List<TEntity>>();
            var lists = await GetAllListAsync(predicate);
            result.total = lists.Count;
            if (PageSize > 0)
            {
                result.pages = (result.total + PageSize - 1) / PageSize;
                lists = lists.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
            }
            result.datas = lists;
            return result;
        }

        protected Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            ParameterExpression expression = Expression.Parameter(typeof(TEntity));
            ParameterExpression[] parameters = new ParameterExpression[] { expression };
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(Expression.PropertyOrField(expression, "Id"), Expression.Constant(id, typeof(TPrimaryKey))), parameters);
        }

    }
}
