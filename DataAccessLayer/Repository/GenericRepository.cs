﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var exist = await dbSet.FindAsync(id);


            if (exist == null) return false;

            dbSet.Remove(exist);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}