using GestorEmpleados.Domain.Repository;
using GestorEmpleados.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Core
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly DbSet<Entity> _dbSet;

        public BaseRepository(EmployeeManagementDBContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<Entity>();

        }

        public virtual async Task Add(Entity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public virtual async Task<Entity> GetById(int id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public virtual async Task<List<Entity>> GetEntity()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Remove(Entity entity)
        {
            this._dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public virtual async Task SaveChanges()
        {
            await this._dbContext.SaveChangesAsync();
        }

        public virtual async Task Update(Entity entity)
        {
            this._dbSet.Update(entity);
            await Task.CompletedTask;
        }
    }
}
