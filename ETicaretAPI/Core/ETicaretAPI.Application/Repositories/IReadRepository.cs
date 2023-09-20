using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //select işlerimini 'IReadRepository' e yazıyoruz.
        IQueryable<T> GetAll(bool tracking = true);
        //şart ifadesinde doğru olan datalar sorgulanıp getirilcek.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        //asenkron çalışan ifadelere task ve async tagı eklenir.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
