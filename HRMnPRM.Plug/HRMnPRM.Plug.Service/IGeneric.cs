using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRMnPRM.Plug.Service
{
    public interface IGeneric<T> where T : class
    {
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(long id);
        //int Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        //T GetById(string id);
        //T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        //IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        int Save();
    }
}
