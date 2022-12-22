using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Todoes.Repository
{
    public interface IRepoData
    {
        Task<ActionResult<IEnumerable<TodoItem>>> Get();
        Task<ActionResult<TodoItem>> Get(int id);
        Task<int> Put(TodoItem item);
        Task<int> Post(TodoItem item);
        Task<ActionResult<TodoItem>> Delete(int id);

    }
    public class RepoData : IRepoData
    {
        private readonly TodoContext _context;
        public RepoData(TodoContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return await _context.TodoItems.ToListAsync();
        }
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }
        public async Task<int> Put(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Post(TodoItem item)
        {
            _context.TodoItems.Add(item);
           return await _context.SaveChangesAsync();

        }
        public async Task<ActionResult<TodoItem>> Delete(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
    }
}
