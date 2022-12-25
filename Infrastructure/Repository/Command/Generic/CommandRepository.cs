﻿using Core.Interface.Command.Generic;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Command.Generic
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly CRUDTESTContext _context;

        public CommandRepository(CRUDTESTContext context)
        {
            _context = context;
        }

       
        public async Task<T> AddAsync(T entity)
        {
            
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

       
        public async Task DeleteAsync(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Set<T>().Remove(entity);           
            await _context.SaveChangesAsync();
        }
    }
}
