using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }
        //.Set<>() methodu ile T türünde set ettik
        public DbSet<T> Table => _context.Set<T>();

        //direk olarak table ı döndürdük
        public IQueryable<T> GetAll()
            => Table;
        //şartı belirterek table döndürdük
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            =>Table.Where(method);
        //async olduğu için await ile birlikte kullandık
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.SingleOrDefaultAsync(method);
        //T inheritini base entity üzerinden aldığı için .id ile direk eşitleme yapabiliyorum
        public async Task<T> GetByIdAsync(string id)
            //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            => await Table.FindAsync(Guid.Parse(id));
    }
}
