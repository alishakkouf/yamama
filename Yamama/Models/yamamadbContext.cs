using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Yamama.Models;

namespace Yamama
{
    public partial class yamamadbContext : IdentityDbContext<ExtendedUser>
    {
        //public yamamadbContext()
        //{
        //}

        public yamamadbContext(DbContextOptions<yamamadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<RequestInformation> RequestInformation { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=yamamadb;UID=root;PWD=0935479586;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(e => e.Idalert)
                    .HasName("PRIMARY");

                entity.ToTable("alert");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.Idalert).HasColumnName("idalert");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.RecieverId).HasColumnName("reciever_id");

                entity.Property(e => e.SenderId).HasColumnName("sender-id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("file_id_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("task_id_al_fk");
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.HasKey(e => e.Idfactory)
                    .HasName("PRIMARY");

                entity.ToTable("factory");

                entity.Property(e => e.Idfactory).HasColumnName("idfactory");

                entity.Property(e => e.ActivityNature)
                    .HasColumnName("activity_nature")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CementPrice)
                    .HasColumnName("cement_price")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.InformationSource)
                    .HasColumnName("information_source")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TransporterId).HasColumnName("transporter_id");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.Idfile)
                    .HasName("PRIMARY");

                entity.ToTable("file");

                entity.Property(e => e.Idfile).HasColumnName("idfile");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.ParentType)
                    .HasColumnName("parent_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Idphoto)
                    .HasName("PRIMARY");

                entity.ToTable("photo");

                entity.Property(e => e.Idphoto).HasColumnName("idphoto");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.Property(e => e.Idproduct).HasColumnName("idproduct");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,0)");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Idproject)
                    .HasName("PRIMARY");

                entity.ToTable("project");

                entity.Property(e => e.Idproject).HasColumnName("idproject");

                entity.Property(e => e.Consultant)
                    .HasColumnName("consultant")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Contractor)
                    .HasColumnName("contractor")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasColumnType("text");

                entity.Property(e => e.InformationSource)
                    .HasColumnName("information_source")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Space)
                    .HasColumnName("space")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<RequestInformation>(entity =>
            {
                entity.HasKey(e => e.IdrequestInformation)
                    .HasName("PRIMARY");

                entity.ToTable("request_information");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.IdrequestInformation).HasColumnName("idrequest_information");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.RecieverId).HasColumnName("reciever_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.RequestInformation)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("file_id_info_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.RequestInformation)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("task_id_info_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrole)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.Idrole).HasColumnName("idrole");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Idtask)
                    .HasName("PRIMARY");

                entity.ToTable("task");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Idtask).HasColumnName("idtask");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("longtext");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("status_id_fk");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("type_id_fk");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.HasKey(e => e.IdtaskStatus)
                    .HasName("PRIMARY");

                entity.ToTable("task_status");

                entity.Property(e => e.IdtaskStatus).HasColumnName("idtask_status");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.IdtaskType)
                    .HasName("PRIMARY");

                entity.ToTable("task_type");

                entity.Property(e => e.IdtaskType).HasColumnName("idtask_type");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Transporter>(entity =>
            {
                entity.HasKey(e => e.Idtransporter)
                    .HasName("PRIMARY");

                entity.ToTable("transporter");

                entity.Property(e => e.Idtransporter).HasColumnName("idtransporter");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.EMail)
                    .HasColumnName("e_mail")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("role_id_fk");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.Idvisit)
                    .HasName("PRIMARY");

                entity.ToTable("visit");

                entity.HasIndex(e => e.FactoryId)
                    .HasName("factory_id");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Idvisit).HasColumnName("idvisit");

                entity.Property(e => e.FactoryId).HasColumnName("factory_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.FactoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("factory_id_fk");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("project_id_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("task_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("user_id_fk");
            });
        }
    }
}
