using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRMnPRM.Plug.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IRepositoryBase<T> _iRepositoryBase;

        public Repository(IRepositoryBase<T> iRepositoryBase)
        {
            this._iRepositoryBase = iRepositoryBase;
        }

        public void Insert(T entity)
        {
            try
            {
                _iRepositoryBase.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _iRepositoryBase.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(T entity)
        {
            try
            {
                _iRepositoryBase.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(long id)
        {
            try
            {
                T obj = _iRepositoryBase.GetById(id);
                _iRepositoryBase.Delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            try
            {
                _iRepositoryBase.Delete(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public T Get(Expression<Func<T, bool>> where)
        {
            try
            {
                return _iRepositoryBase.Get(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public T GetById(long id)
        {
            try
            {
                return _iRepositoryBase.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public T GetById(string id)
        {
            try
            {
                return _iRepositoryBase.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<T> GetAll()
        {
            try
            {
                return _iRepositoryBase.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<T> GetMany(Expression<Func<T, bool>> where)
        {
            try
            {
                return _iRepositoryBase.GetMany(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
