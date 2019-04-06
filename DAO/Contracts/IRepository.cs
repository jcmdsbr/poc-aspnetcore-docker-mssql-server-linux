using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAO.Models;

namespace DAO.Contracts {
    public interface IRepository {
        Task<Todo> FindAsync (Guid id);

        Task<bool> AnyAsync (Guid id);
        Task<IEnumerable<Todo>> List ();

        Task AddAsync (Todo entity);

        Task UpdateAsync (Todo entity);

        Task DeleteAsync (Guid id);

        Task Commit ();
    }
}