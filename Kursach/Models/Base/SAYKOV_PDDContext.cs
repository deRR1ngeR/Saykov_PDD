using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kursach.Models.Base
{
    public partial class SAYKOV_PDDContext : DbContext
    {
        public SAYKOV_PDDContext()
        {
        }

        public SAYKOV_PDDContext(DbContextOptions<SAYKOV_PDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Fine> Fines { get; set; } = null!;
        public virtual DbSet<FineThem> FineThems { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<PddInfo> PddInfos { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketResult> TicketResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-VFH74HFU\\SQLEXPRESS;Initial Catalog=SAYKOV_PDD;Trusted_Connection = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.AnswersId);

                entity.Property(e => e.AnswersId).HasColumnName("Answers_Id");

                entity.Property(e => e.Answer1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Answer");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.RightAnswer).HasColumnName("Right_answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answers_Question");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("Fine");

                entity.Property(e => e.FineCost)
                    .HasMaxLength(15)
                    .HasColumnName("Fine_Cost");

                entity.Property(e => e.FineImg)
                    .HasMaxLength(250)
                    .HasColumnName("Fine_img");

                entity.Property(e => e.FineText)
                    .HasMaxLength(350)
                    .HasColumnName("Fine_Text")
                    .IsFixedLength();

                entity.Property(e => e.FineTime)
                    .HasMaxLength(20)
                    .HasColumnName("Fine_Time")
                    .IsFixedLength();

                entity.HasOne(d => d.FineThem)
                    .WithMany(p => p.Fines)
                    .HasForeignKey(d => d.FineThemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fine_FineThem");
            });

            modelBuilder.Entity<FineThem>(entity =>
            {
                entity.HasKey(e => e.FineId)
                    .HasName("PK_PDD_Fine");

                entity.ToTable("FineThem");

                entity.Property(e => e.FineId).HasColumnName("Fine_id");

                entity.Property(e => e.FineText)
                    .HasMaxLength(350)
                    .HasColumnName("Fine_Text")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Login__D78B57AFB525EC6C");

                entity.ToTable("Login");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("regDate");
                entity.Property(e => e.LastEnter)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("LastEnter");
                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PddInfo>(entity =>
            {
                entity.HasKey(e => e.PddId);

                entity.ToTable("PDD_Info");

                entity.Property(e => e.PddId).HasColumnName("PDD_id");

                entity.Property(e => e.PddImg)
                    .HasMaxLength(100)
                    .HasColumnName("PDD_img");

                entity.Property(e => e.PddText)
                    .HasMaxLength(350)
                    .HasColumnName("PDD_Text");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Question_id");

                entity.Property(e => e.NumberInTicket).HasColumnName("Number_in_ticket");

                entity.Property(e => e.QuestionImg)
                    .HasMaxLength(150)
                    .HasColumnName("Question_img");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("Question_text");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Ticket1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ticket_id");

                entity.Property(e => e.TicketResult)
                    .HasMaxLength(150)
                    .HasColumnName("Ticket_result");
            });

            modelBuilder.Entity<TicketResult>(entity =>
            {
                entity.ToTable("Ticket_results");

                entity.Property(e => e.TicketResultId).HasColumnName("Ticket_resultID");

                entity.Property(e => e.ResDate).HasColumnType("smalldate");

                entity.Property(e => e.TicketId).HasColumnName("ticketId");
                entity.Property(e => e.isPassed).HasColumnName("isPassed");
                entity.Property(e => e.TicketResult1)
                    .HasMaxLength(150)
                    .HasColumnName("Ticket_Result");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TicketResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_results_Login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
