using BeaverStream.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BeaverStream.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Thread> Threads { get; set; }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region THREAD

            modelBuilder.Entity<Thread>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Thread>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Thread>()
                .HasIndex(t => t.CreatedAt)
                .HasDatabaseName("IX_Threads_CreatedAt");

            modelBuilder.Entity<Thread>()
                .HasIndex(t => t.isHidden)
                .HasDatabaseName("IX_Threads_IsHidden");

            modelBuilder.Entity<Thread>()
                .HasIndex(t => new { t.CreatedAt, t.isHidden })
                .HasDatabaseName("IX_Threads_CreatedAt_IsHidden");
            #endregion


            #region MESSAGE
            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.CreatedAt)
                .HasDatabaseName("IX_Messages_CreatedAt");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.ThreadId)
                .HasDatabaseName("IX_Messages_ThreadId");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.ParentMessage)
                .HasDatabaseName("IX_Messages_ParentMessageId");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.IsOp)
                .HasDatabaseName("IX_Messages_IsOp");

            modelBuilder.Entity<Message>()
                .HasIndex(m => m.UserId)
                .HasDatabaseName("IX_Messages_UserId");



            //СВЯЗИ

            //Message <-> Thread: Удаление треда -> удаление всех сообщений
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Thread)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.ThreadId)
                .OnDelete(DeleteBehavior.Cascade);

            //Удаление сообщения -> удаление всех ответов
            modelBuilder.Entity<Message>()
                .HasMany(m => m.Replies)
                .WithOne(m => m.ParentMessage)
                .HasForeignKey(m => m.ParentMessage)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            //Message <-> User: Удаление пользователя -> сообщения остаются
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // UserId становится null



            //ПРАВИЛА

            //1 Title обязателен только для OP-сообщений
            modelBuilder.Entity<Message>()
                .HasCheckConstraint(
                    "CK_Message_Title_OnlyForOp",
                    @$"(""IsOp"" = 1 AND ""Title"" IS NOT NULL AND LENGTH(TRIM(""Title"")) > 0) OR 
                      (""IsOp"" = 0 AND ""Title"" IS NULL)");

            //2 У OP-сообщения не должно быть ParentMessageId
            modelBuilder.Entity<Message>()
                .HasCheckConstraint(
                    "CK_Message_OpNoParent",
                    @$"(""IsOp"" = 1 AND ""ParentMessageId"" IS NULL) OR 
                      (""IsOp"" = 0)");

            //3 ThreadId обязателен для всех сообщений
            modelBuilder.Entity<Message>()
                .HasCheckConstraint(
                    "CK_Message_ThreadIdRequired",
                    @$"""ThreadId"" IS NOT NULL");

            //4 Text не может быть пустым
            modelBuilder.Entity<Message>()
                .HasCheckConstraint(
                    "CK_Message_TextNotEmpty",
                    @$"""Text"" IS NOT NULL AND LENGTH(TRIM(""Text"")) > 0");

            #endregion



            #region USER
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique()
                .HasDatabaseName("IX_Users_Name");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.isAdmin)
                .HasDatabaseName("IX_Users_IsAdmin");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.isBannedAll)
                .HasDatabaseName("IX_Users_IsBannedAll");

            modelBuilder.Entity<User>()
                .Property(u => u.BannedInTreads)
                .HasColumnType("jsonb")
                .HasConversion(
                    v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => v == null ? new List<int>() : JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions)null)
                );
            #endregion

            //ДОПОЛНИТЕЛЬНЫЕ НАСТРОЙКИ

            //Для PostgreSQL
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                //Таблицы
                entity.SetTableName(entity.GetTableName().ToLower());

                //Колонки
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }
            }
        }
    }
}