using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess
{
    public class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : class
    {
        protected readonly PersonalContext _context;
        protected readonly IHttpContextAccessor accessor;
        private readonly DbSet<TModel> _model;
        public BaseRepository(PersonalContext context, IHttpContextAccessor _accessor)
        {
            _context = context;
            accessor = _accessor;
            _model = _context.Set<TModel>();
        }
        public virtual async Task<OperationResult> AddAsync(TModel model)
        {
            var res = new OperationResult(_model.ToString());
            try
            {
                await _model.AddAsync(model);
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }
        }
        public virtual TModel Update(TModel model)
        {
            var res = new OperationResult(_model.ToString());
            try
            {
                _context.Set<TModel>().Attach(model);
                _context.Entry(model).State = EntityState.Modified;
                res.Success = true;
                return model;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return model;
            }
        }
        public virtual async Task<OperationResult> DeleteAsync(TModel model)
        {
            var res = new OperationResult(_model.ToString());
            try
            {
                _model.Remove(model);
                await SaveAsync();

                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }
        }
        public virtual async Task<OperationResult> DeleteAllAsync(IQueryable<TModel> deleteModels)
        {
            var res = new OperationResult(_model.ToString());
            try
            {
                _context.Set<TModel>().RemoveRange(deleteModels.AsEnumerable());
                await SaveAsync();
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }
        }
        public virtual async Task<OperationResult> DeleteAsync(TKey id)
        {
            var res = new OperationResult(_model.ToString());

            try
            {
                var model = await GetAsync(id);
                if (model != null)
                {
                    _model.Remove(model);
                    await SaveAsync();
                    res.Success = true;
                    return res;
                }
                else
                    res.Message = "Model not found";

            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }
        public async Task<TModel> GetAsync(TKey id)
        {
            var model = await _model.FindAsync(id);
            return model;
        }
        public IQueryable<TModel> GetAllAsQueryable(bool asNoTracking = false)
        {
            return asNoTracking ? _model.AsNoTracking().AsQueryable() : _model.AsQueryable();
        }
        public IQueryable<TModel> GetAllAsQueryable(Func<TModel, bool> predicate, bool asNoTracking = false)
        {
            return asNoTracking ? _model.AsNoTracking().AsEnumerable().Where(predicate).AsQueryable() : _model.Where(predicate).AsQueryable();
        }
        public IQueryable<TModel> AllIncluding(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null, bool asNoTracking = false)
        {
            IQueryable<TModel> query = asNoTracking ? _model.AsNoTracking().AsQueryable() : _model.AsQueryable();
            if (include != null)
                query = include(query);

            return query;
        }
        public TModel GetInclude(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include, Func<TModel, bool> predicate)
        {
            IQueryable<TModel> query = _model.AsQueryable();
            query = include(query);
            query = query.Where(predicate).AsQueryable();

            var res = query.FirstOrDefault();
            return res;

        }
        public async Task<OperationResult> SaveAsync()
        {
            var res = new OperationResult(_model.ToString());
            try
            {
                await _context.SaveChangesAsync();
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message.ToString();
                return res;
            }
        }
        
        public void Dispose()
        {
            // throw new NotImplementedException();
        }
        public IQueryable<TModel> Paginated(int pageSize, IQueryable<TModel> Models, int pageIndex = 1, bool asNoTracking = false)
        {
            return Models.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

    }

}