using Microsoft.EntityFrameworkCore;
using LanguageLearningAPI.Models;

namespace LanguageLearningAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<LearningPlan> LearningPlans => Set<LearningPlan>();
        public DbSet<TranslationGroup> TranslationGroups => Set<TranslationGroup>();
        public DbSet<TranslationPair> TranslationPairs => Set<TranslationPair>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names mirror .ai/db/db-instructions.md
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasIndex(u => u.Username).IsUnique();
                // Persist enum as text to satisfy the CHECK ('Admin','Learner') constraint
                entity.Property(u => u.UserType).HasConversion<string>();
            });

            modelBuilder.Entity<LearningPlan>(entity =>
            {
                entity.ToTable("LearningPlan");
                // GroupIDs is a JSONB column in PostgreSQL
                entity.Property(p => p.GroupIDs).HasColumnType("jsonb");
                entity.HasOne(p => p.User)
                      .WithMany()
                      .HasForeignKey(p => p.UserID);
            });

            modelBuilder.Entity<TranslationGroup>(entity =>
            {
                entity.ToTable("TranslationGroups");
                // Persist enum as text; existing rows default to 'Beginner'.
                entity.Property(g => g.Level)
                      .HasConversion<string>()
                      .HasDefaultValue(GroupLevel.Beginner);
            });

            modelBuilder.Entity<TranslationPair>(entity =>
            {
                entity.ToTable("TranslationPairs");
                // Persist enum as text to satisfy the CHECK ('word','phrase','sentence') constraint
                entity.Property(p => p.Type).HasConversion<string>();
                entity.HasOne(p => p.TranslationGroup)
                      .WithMany(g => g.TranslationPairs)
                      .HasForeignKey(p => p.GroupID);
            });
        }
    }
}
