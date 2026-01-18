using BeaverStream.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Thread = BeaverStream.Models.Thread;

namespace BeaverStream.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурация для Thread
            modelBuilder.Entity<Thread>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Thread>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Thread>()
                .HasIndex(t => t.CreatedAt);

            // Конфигурация для Message
            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.CreatedAt);

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.ThreadId);

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.ParentMessage);

            // Связь: Message <-> Thread (один ко многим)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Thread)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.ThreadId)
                .OnDelete(DeleteBehavior.Cascade); // При удалении треда удаляются все сообщения

            // Связь: Message <-> Message (самореферентная, для Replies)
            modelBuilder.Entity<Message>()
                .HasMany(m => m.Replies)
                .WithOne(m => m.ParentMessage)
                .HasForeignKey(m => m.ParentMessage)
                .IsRequired(false) // У OP-сообщения ParentMessageId = null
                .OnDelete(DeleteBehavior.Restrict); // Или Cascade, но осторожно с рекурсией

            // Связь: Message <-> User (многие к одному)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId)
                .IsRequired(false) // Сообщение может быть от анонима
                .OnDelete(DeleteBehavior.SetNull); // При удалении пользователя сообщения остаются

            // Валидация: Title должен быть только у OP-сообщений
            modelBuilder.Entity<Message>()
                .HasCheckConstraint("CK_Message_Title_OnlyForOp",
                    @$"(""IsOp"" = 1 AND ""Title"" IS NOT NULL AND LENGTH(TRIM(""Title"")) > 0) OR 
                      (""IsOp"" = 0 AND ""Title"" IS NULL)");

            // Дополнительно: можно добавить проверку, что у OP-сообщения ParentMessageId = null
            modelBuilder.Entity<Message>()
                .HasCheckConstraint("CK_Message_OpNoParent",
                    @$"(""IsOp"" = 1 AND ""ParentMessageId"" IS NULL) OR 
                      (""IsOp"" = 0)");

            // Конфигурация для User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique(); // Имена пользователей должны быть уникальными

            // Обработка BannedInThreads (список ID через JSON или массив)
            // В зависимости от используемой БД (PostgreSQL поддерживает массивы)
            modelBuilder.Entity<User>()
                .Property(u => u.BannedInTreads)
                .HasColumnType("jsonb") // Для PostgreSQL
                .HasConversion(
                    v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => v == null ? new List<int>() : JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions)null)
                );
        }
    }
}