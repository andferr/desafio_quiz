using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public virtual DbSet<Answers> Answers { get; set; }

        public virtual DbSet<Questions> Questions { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("answers");

                entity.HasIndex(e => e.Question, "fk_question_idx");

                entity.HasIndex(e => e.User, "fk_user_idx");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AnswerValue).HasColumnName("answer_value");
                entity.Property(e => e.Bonus).HasColumnName("bonus");
                entity.Property(e => e.Correct).HasColumnName("correct");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.Question).HasColumnName("quiz");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.QuestionNavigation).WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question");

                entity.HasOne(d => d.UserNavigation).WithMany(p => p.Answers)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("questions");

                entity.HasIndex(e => e.Owner, "fk_owner_idx");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CorrectAnswer).HasColumnName("correct_answer");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.FifthOption)
                    .HasMaxLength(150)
                    .HasColumnName("fifth_option");
                entity.Property(e => e.FirstOption)
                    .HasMaxLength(150)
                    .HasColumnName("first_option");
                entity.Property(e => e.FourthOption)
                    .HasMaxLength(150)
                    .HasColumnName("fourth_option");
                entity.Property(e => e.Owner).HasColumnName("owner");
                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("question");
                entity.Property(e => e.SecondOption)
                    .HasMaxLength(150)
                    .HasColumnName("second_option");
                entity.Property(e => e.SecretNumber).HasColumnName("secret_number");
                entity.Property(e => e.ThirdOption)
                    .HasMaxLength(150)
                    .HasColumnName("third_option");
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasDefaultValueSql("'MULTIPLE'")
                    .HasColumnType("enum('MULTIPLE','NUMBER')")
                    .HasColumnName("type");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_owner");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Admin).HasColumnName("admin");
                entity.Property(e => e.Ativated).HasColumnName("ativated");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("password_hash");
                entity.Property(e => e.Score).HasColumnName("score");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
