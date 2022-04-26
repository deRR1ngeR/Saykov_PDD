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

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamResult> ExamResults { get; set; } = null!;
        public virtual DbSet<Fine> Fines { get; set; } = null!;
        public virtual DbSet<FineThem> FineThems { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<PddInfo> PddInfos { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketExam> TicketExams { get; set; } = null!;
        public virtual DbSet<TicketResult> TicketResults { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = LAPTOP-VFH74HFU\\SQLEXPRESS; Database = SAYKOV_PDD; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("Admin_id");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DateOfEntry)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_entry");

                entity.Property(e => e.LoginId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Login_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Patronim)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.Surname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin__Login_id__38996AB5");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.ExamId).HasColumnName("Exam_id");

                entity.Property(e => e.ExamResult)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Exam_result");

                entity.HasOne(d => d.ExamResultNavigation)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.ExamResult)
                    .HasConstraintName("FK_Exam_Exam_results");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasKey(e => e.ExamResults);

                entity.ToTable("Exam_results");

                entity.Property(e => e.ExamResults)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Exam_Results");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("Fine");

                entity.Property(e => e.FineId).ValueGeneratedNever();

                entity.Property(e => e.FineCost).HasColumnName("Fine_Cost");

                entity.Property(e => e.Fine_Text)
                    .HasMaxLength(350)
                    .HasColumnName("Fine_Text")
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
                entity.ToTable("Login");

                entity.Property(e => e.LoginId).HasColumnName("Login_id");

                entity.Property(e => e.LoginName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Login_name");

                entity.Property(e => e.Passwords)
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

                entity.Property(e => e.Answer1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Answer_1");

                entity.Property(e => e.Answer2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Answer_2");

                entity.Property(e => e.Answer3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Answer_3");

                entity.Property(e => e.QuestionImg)
                    .HasMaxLength(100)
                    .HasColumnName("Question_img");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("Question_text");

                entity.Property(e => e.RightAnswer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Right_answer");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ticket_id");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Ticket");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_id");

                entity.Property(e => e.TicketResult)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Ticket_result");

                entity.HasOne(d => d.TicketResultNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TicketResult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Ticket_results");
            });

            modelBuilder.Entity<TicketExam>(entity =>
            {
                entity.ToTable("Ticket_Exam");

                entity.Property(e => e.ExamId).HasColumnName("Exam_id");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.TicketExams)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__Ticket_Ex__Exam___44FF419A");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketExams)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_Ticket_Exam_Ticket");
            });

            modelBuilder.Entity<TicketResult>(entity =>
            {
                entity.HasKey(e => e.TicketResult1);

                entity.ToTable("Ticket_results");

                entity.Property(e => e.TicketResult1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Ticket_result");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_id");

                entity.Property(e => e.Exam)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Login_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Patronim)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Results)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExamNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Exam)
                    .HasConstraintName("FK_Users_Exam_results");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Login_id__52593CB8");

                entity.HasOne(d => d.ResultsNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Results)
                    .HasConstraintName("FK_Users_Ticket_results");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
