using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Yamama
{
    public partial class yamamadbContext : DbContext
    {
        //public yamamadbContext()
        //{
        //}

        public yamamadbContext(DbContextOptions<yamamadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<RequestInformation> RequestInformation { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=localhost;Database=yamamadb;UID=root;PWD=root123;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasKey(e => e.Idbalance)
                    .HasName("PRIMARY");

                entity.ToTable("balance");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Idbalance).HasColumnName("idbalance");

                entity.Property(e => e.DateOfFirst)
                    .HasColumnName("date_of_first")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfLast)
                    .HasColumnName("date_of_last")
                    .HasColumnType("date");

                entity.Property(e => e.FirstPeriod).HasColumnName("first_period");

                entity.Property(e => e.LastPeriod).HasColumnName("last_period");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_balanc_fk");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Idcart)
                    .HasName("PRIMARY");

                entity.ToTable("cart");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Idcart).HasColumnName("idcart");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SubCost).HasColumnName("Sub_Cost");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("cart_invoice_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("cart_product_fk");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.HasKey(e => e.Idfactory)
                    .HasName("PRIMARY");

                entity.ToTable("factory");

                entity.HasIndex(e => e.Idfactory)
                    .HasName("idfactory_UNIQUE")
                    .IsUnique();

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

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idinvoice)
                    .HasName("PRIMARY");

                entity.ToTable("invoice");

                entity.HasIndex(e => e.FactoryId)
                    .HasName("factory_id");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.Idinvoice).HasColumnName("idinvoice");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FactoryId).HasColumnName("factory_id");

                entity.Property(e => e.FullCost).HasColumnName("full_cost");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.RemainForCustomer).HasColumnName("remain_for_Customer");

                entity.Property(e => e.RemainForYamama).HasColumnName("remain_for_yamama");

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.FactoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("factory_invoice_fk");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("project_invoice_fk");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Idphoto)
                    .HasName("PRIMARY");

                entity.ToTable("photo");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.Idphoto).HasColumnName("idphoto");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("photo_project_id_fk");
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

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(e => e.Idproduction)
                    .HasName("PRIMARY");

                entity.ToTable("production");

                entity.HasIndex(e => e.Idproduction)
                    .HasName("idproduction_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Idproduction).HasColumnName("idproduction");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_production_fk");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Idproject)
                    .HasName("PRIMARY");

                entity.ToTable("project");

                entity.HasIndex(e => e.Idproject)
                    .HasName("idproject_UNIQUE")
                    .IsUnique();

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

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Idstore)
                    .HasName("PRIMARY");

                entity.ToTable("store");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Idstore).HasColumnName("idstore");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_store_fk");
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
