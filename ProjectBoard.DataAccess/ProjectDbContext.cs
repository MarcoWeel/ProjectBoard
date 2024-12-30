using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBoard.Model;


namespace ProjectBoard.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> opts) : base(opts)
        {

        }

        public DbSet<Model.Project> Projects { get; set; }
        public DbSet<Model.Step> Steps { get; set; }
    }
}
