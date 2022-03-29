using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class EduPortalContext : DbContext
    {
        public EduPortalContext()
        {
        }

        public EduPortalContext(DbContextOptions<EduPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcadmicStatus> AcadmicStatus { get; set; }
        public virtual DbSet<ChatGroup> ChatGroup { get; set; }
        public virtual DbSet<Chats> Chats { get; set; }
        public virtual DbSet<Collage> Collage { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Metting> Metting { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<PreRequest> PreRequest { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Spectialization> Spectialization { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAttendanceRecord> StudentAttendanceRecord { get; set; }
        public virtual DbSet<StudentTakeExam> StudentTakeExam { get; set; }
        public virtual DbSet<StudentTask> StudentTask { get; set; }
        public virtual DbSet<StudentsFinishMaterial> StudentsFinishMaterial { get; set; }
        public virtual DbSet<StudentsSession> StudentsSession { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TAH-LAP-JOR195\\SQLEXPRESS;Database=EduPortal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcadmicStatus>(entity =>
            {
                entity.Property(e => e.AcadmicStatusId).HasColumnName("AcadmicStatusID");

                entity.Property(e => e.ArabicName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatGroup>(entity =>
            {
                entity.Property(e => e.ChatGroupId).HasColumnName("ChatGroupID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastActive).HasColumnType("datetime");

                entity.Property(e => e.LastMassage).HasMaxLength(500);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.ChatGroup)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_ChatGroup_Session");
            });

            modelBuilder.Entity<Chats>(entity =>
            {
                entity.Property(e => e.ChatsId).HasColumnName("ChatsID");

                entity.Property(e => e.ChatGroupId).HasColumnName("ChatGroupID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.ChatGroupId)
                    .HasConstraintName("FK_Chats_ChatGroup");
            });

            modelBuilder.Entity<Collage>(entity =>
            {
                entity.Property(e => e.CollageId).HasColumnName("CollageID");

                entity.Property(e => e.ArabicName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.ArabicDescription).IsUnicode(false);

                entity.Property(e => e.ArabicName).IsUnicode(false);

                entity.Property(e => e.CourseAssociatedId).HasColumnName("CourseAssociatedID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.SpectializationId).HasColumnName("SpectializationID");

                entity.HasOne(d => d.CourseAssociated)
                    .WithMany(p => p.InverseCourseAssociated)
                    .HasForeignKey(d => d.CourseAssociatedId)
                    .HasConstraintName("FK_Course_Course");

                entity.HasOne(d => d.Spectialization)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.SpectializationId)
                    .HasConstraintName("FK_Course_Spectialization");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EndDateandTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateandTime).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Exam_Course");
            });

            modelBuilder.Entity<Goals>(entity =>
            {
                entity.Property(e => e.ArabicDescription)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ArabicTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Goals_Course");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasIndex(e => e.UniversityId)
                    .HasName("IX_Login");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.ConnectionString).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastLogout).HasColumnType("datetime");

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath).IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UploadedAt)
                    .HasColumnName("UploadedAT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Material_Session");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttachedFile).IsUnicode(false);

                entity.Property(e => e.AttachedImage).IsUnicode(false);

                entity.Property(e => e.AttachedVideo).IsUnicode(false);

                entity.Property(e => e.IsSenderTeacher).HasColumnName("isSenderTeacher");

                entity.Property(e => e.MassageDate).HasColumnType("datetime");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");
            });

            modelBuilder.Entity<Metting>(entity =>
            {
                entity.Property(e => e.MettingId).HasColumnName("MettingID");

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Metting)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Metting_Session");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Option_Question");
            });

            modelBuilder.Entity<PreRequest>(entity =>
            {
                entity.Property(e => e.PreRequestId).HasColumnName("PreRequestID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.PrevouisCourseId).HasColumnName("PrevouisCourseID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_Question_QuestionType");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistrationStatus>(entity =>
            {
                entity.Property(e => e.RegistrationStatusId).HasColumnName("RegistrationStatusID");

                entity.Property(e => e.ArabicName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EndAt).HasColumnType("date");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.StartAt).HasColumnType("date");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Session_Course");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK_Session_Schedule");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Session_Teacher");
            });

            modelBuilder.Entity<Spectialization>(entity =>
            {
                entity.Property(e => e.SpectializationId).HasColumnName("SpectializationID");

                entity.Property(e => e.ArabicDescription).IsUnicode(false);

                entity.Property(e => e.ArabicName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CollageId).HasColumnName("CollageID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Collage)
                    .WithMany(p => p.Spectialization)
                    .HasForeignKey(d => d.CollageId)
                    .HasConstraintName("FK_Spectialization_Collage");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.AcadmicStatusId).HasColumnName("AcadmicStatusID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationStatusId).HasColumnName("RegistrationStatusID");

                entity.Property(e => e.SpectializationId).HasColumnName("SpectializationID");

                entity.HasOne(d => d.AcadmicStatus)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AcadmicStatusId)
                    .HasConstraintName("FK_Student_AcadmicStatus");

                entity.HasOne(d => d.RegistrationStatus)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.RegistrationStatusId)
                    .HasConstraintName("FK_Student_RegistrationStatus");

                entity.HasOne(d => d.Spectialization)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SpectializationId)
                    .HasConstraintName("FK_Student_Spectialization");
            });

            modelBuilder.Entity<StudentAttendanceRecord>(entity =>
            {
                entity.Property(e => e.StudentAttendanceRecordId).HasColumnName("StudentAttendanceRecordID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.StudentAttendanceRecord)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_StudentAttendanceRecord_Session");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttendanceRecord)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentAttendanceRecord_Student");
            });

            modelBuilder.Entity<StudentTakeExam>(entity =>
            {
                entity.Property(e => e.StudentTakeExamId)
                    .HasColumnName("StudentTakeExamID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndExamAt).HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StartExamAt).HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentTakeExam)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_StudentTakeExam_Exam");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTakeExam)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentTakeExam_Student");
            });

            modelBuilder.Entity<StudentTask>(entity =>
            {
                entity.Property(e => e.StudentTaskId).HasColumnName("StudentTaskID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.TeacherResponse).HasMaxLength(500);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTask)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentTask_Student");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.StudentTask)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_StudentTask_StudentTask");
            });

            modelBuilder.Entity<StudentsFinishMaterial>(entity =>
            {
                entity.Property(e => e.StudentsFinishMaterialId)
                    .HasColumnName("StudentsFinishMaterialID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.StudentsFinishMaterial)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_StudentsFinishMaterial_Material");

                entity.HasOne(d => d.StudentsFinishMaterialNavigation)
                    .WithOne(p => p.StudentsFinishMaterial)
                    .HasForeignKey<StudentsFinishMaterial>(d => d.StudentsFinishMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsFinishMaterial_Student");
            });

            modelBuilder.Entity<StudentsSession>(entity =>
            {
                entity.Property(e => e.StudentsSessionId).HasColumnName("StudentsSessionID");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.StudentsSession)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_StudentsSession_Session");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsSession)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentsSession_Student");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.FilePath).IsUnicode(false);

                entity.Property(e => e.LastAllowedSubmmation).HasColumnType("datetime");

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Task_Session");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Pio).IsUnicode(false);

                entity.Property(e => e.SpectializationId).HasColumnName("SpectializationID");

                entity.HasOne(d => d.Spectialization)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.SpectializationId)
                    .HasConstraintName("FK_Teacher_Spectialization");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.Property(e => e.ArabicSubTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ArabicTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.SubTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Topic_Course");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
