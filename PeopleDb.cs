using AzureWebsite.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureWebsite.Api
{
    public class PeopleDb : DbContext
{
    public PeopleDb(DbContextOptions<PeopleDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigurePersonEntity(modelBuilder.Entity<Person>());
    }

    private void ConfigurePersonEntity(EntityTypeBuilder<Person> entity)
    {
        entity.ToTable("Person");

        entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        entity.Property(p => p.PhoneNumber).HasMaxLength(20).IsRequired(false); // Corrected property name
    }
    
    public DbSet<Person> People { get; set; } // Corrected DbSet property declaration
}

}