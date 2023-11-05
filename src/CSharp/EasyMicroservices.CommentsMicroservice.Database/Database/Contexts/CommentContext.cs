using EasyMicroservices.CommentsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.CommentsMicroservice.Database.Contexts
{
    public class CommentContext : RelationalCoreContext
    {
        IEntityFrameworkCoreDatabaseBuilder _builder;
        public CommentContext(IEntityFrameworkCoreDatabaseBuilder builder) : base(builder)
        {
        }

        public DbSet<CommentEntity> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_builder != null)
                _builder.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CommentEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });

        }
    }
}