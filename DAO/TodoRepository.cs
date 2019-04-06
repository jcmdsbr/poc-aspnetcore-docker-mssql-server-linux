using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAO.Contracts;
using DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO {
    public class TodoRepository : IRepository, IDisposable {
        private readonly DbSet<Todo> _session;
        private readonly Context _context;
        public TodoRepository (Context context) {
            _context = context;
            _session = context.Set<Todo> ();
        }
        public async Task AddAsync (Todo entity) {
            await _session.AddAsync (entity);
        }

        public async Task<bool> AnyAsync (Guid id) {
            return await _session.AnyAsync (x => x.Id == id);
        }

        public async Task DeleteAsync (Guid id) {
            var entity = await _session.FindAsync (id);
            _session.Remove (entity);
        }

        public async Task<Todo> FindAsync (Guid id) {
            return await _session.FindAsync (id);
        }

        public async Task<IEnumerable<Todo>> List () {
            return await _session.ToListAsync ();
        }
        public async Task UpdateAsync (Todo entity) {
            var entry = await _session.AddAsync (entity);
            entry.State = EntityState.Modified;
        }

        public async Task Commit () {
            await _context.SaveChangesAsync ();
        }

        public void Dispose () {
            _context.Dispose ();
        }
    }
}