using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application
{
    public interface INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
