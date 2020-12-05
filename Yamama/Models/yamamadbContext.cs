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

        public virtual DbSet<ActualIntencive> ActualIntencive { get; set; }
        public virtual DbSet<ActualNeeds> ActualNeeds { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CustomerSatisfactionReports> CustomerSatisfactionReports { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<ExpectedIntencive> ExpectedIntencive { get; set; }
        public virtual DbSet<ExpectedNeeds> ExpectedNeeds { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<LinkRQA> LinkRQA { get; set; }
        public virtual DbSet<MoneyDelivered> MoneyDelivered { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<QModelNames> QModelNames { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RequestInformation> RequestInformation { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
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
            modelBuilder.Entity<ActualIntencive>(entity =>
            {
                entity.HasKey(e => e.IdactualIntencive)
                    .HasName("PRIMARY");

                entity.ToTable("actual_intencive");

                entity.HasIndex(e => e.IdUser)
                    .HasName("id_user_idx");

                entity.Property(e => e.IdactualIntencive).HasColumnName("idactual_intencive");

                entity.Property(e => e.ActualIntencive1).HasColumnName("actual_intencive");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ActualIntencive)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("id_user");
            });

            modelBuilder.Entity<ActualNeeds>(entity =>
            {
                entity.HasKey(e => e.IdactualNeeds)
                    .HasName("PRIMARY");

                entity.ToTable("actual_needs");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("product_id_idx");

                entity.Property(e => e.IdactualNeeds).HasColumnName("idactual_needs");

                entity.Property(e => e.ActualNeeds1).HasColumnName("actual_needs1");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ActualNeeds)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("id_product");
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(e => e.Idalert)
                    .HasName("PRIMARY");

                entity.ToTable("alert");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.RecieverId)
                    .HasName("reciever_id");

                entity.HasIndex(e => e.SenderId)
                    .HasName("sender_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.Idalert).HasColumnName("idalert");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.RecieverId)
                    .HasColumnName("reciever_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SenderId)
                    .HasColumnName("sender_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("alert_file_fk");

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.AlertReciever)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("alert_receiver_fk");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.AlertSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("alert_sender_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("alert_task_fk");
            });

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Idanswers)
                    .HasName("PRIMARY");

                entity.ToTable("answers");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("question_id_idx");

                entity.Property(e => e.Idanswers).HasColumnName("idanswers");

                entity.Property(e => e.AnswerText)
                    .HasColumnName("answer_text")
                    .HasColumnType("text");

                entity.Property(e => e.AnswerWeight).HasColumnName("answer_weight");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("question_id");
            });

            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetRoleClaims_Role");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetuserClaims_user");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(255)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.FullName).HasColumnType("longtext");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(255)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(255)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetuserToken_User");
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasKey(e => e.Idbalance)
                    .HasName("PRIMARY");

                entity.ToTable("balance");

                entity.HasIndex(e => e.ProductId1)
                    .HasName("product_id_idx");

                entity.Property(e => e.Idbalance).HasColumnName("idbalance");

                entity.Property(e => e.DateOfFirst)
                    .HasColumnName("date_of_first")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfLast)
                    .HasColumnName("date_of_last")
                    .HasColumnType("date");

                entity.Property(e => e.FirstPeriod).HasColumnName("first_period");

                entity.Property(e => e.LastPeriod).HasColumnName("last_period");

                entity.Property(e => e.ProductId1).HasColumnName("product_id1");

                entity.HasOne(d => d.ProductId1Navigation)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.ProductId1)
                    .HasConstraintName("product_id1");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PRIMARY");

                entity.ToTable("cart");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("InvoiceId_idx");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId_idx");

                entity.HasIndex(e => e.TransportedId)
                    .HasName("transported_id_idx");

                entity.Property(e => e.IdCart).HasColumnName("idCart");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.TransportedId).HasColumnName("transported_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("InvoiceId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductId");

                entity.HasOne(d => d.Transported)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.TransportedId)
                    .HasConstraintName("transported_id");
            });

            modelBuilder.Entity<CustomerSatisfactionReports>(entity =>
            {
                entity.HasKey(e => e.IdcustomerSatisfactionReports)
                    .HasName("PRIMARY");

                entity.ToTable("customer_satisfaction_reports");

                entity.HasIndex(e => e.FactoryId)
                    .HasName("factory_id_idx");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id_idx");

                entity.Property(e => e.IdcustomerSatisfactionReports).HasColumnName("idcustomer_satisfaction_reports");

                entity.Property(e => e.FactoryId).HasColumnName("factory_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.SatisfactionEvaluation).HasColumnName("satisfaction_evaluation");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.CustomerSatisfactionReports)
                    .HasForeignKey(d => d.FactoryId)
                    .HasConstraintName("factory_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomerSatisfactionReports)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("project_id");
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

            modelBuilder.Entity<ExpectedIntencive>(entity =>
            {
                entity.HasKey(e => e.IdexpectedIntencive)
                    .HasName("PRIMARY");

                entity.ToTable("expected_intencive");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id_idx");

                entity.Property(e => e.IdexpectedIntencive).HasColumnName("idexpected_intencive");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpectedMoney).HasColumnName("expected_money");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExpectedIntencive)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_id");
            });

            modelBuilder.Entity<ExpectedNeeds>(entity =>
            {
                entity.HasKey(e => e.IdexpectedNeeds)
                    .HasName("PRIMARY");

                entity.ToTable("expected_needs");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id_idx");

                entity.Property(e => e.IdexpectedNeeds).HasColumnName("idexpected_needs");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpectedQuantity).HasColumnName("expected_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ExpectedNeeds)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("product_id");
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.HasKey(e => e.Idfactory)
                    .HasName("PRIMARY");

                entity.ToTable("factory");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.HasIndex(e => e.TransporterId)
                    .HasName("transporter");

                entity.Property(e => e.Idfactory).HasColumnName("idfactory");

                entity.Property(e => e.ActivityNature)
                    .HasColumnName("activity_nature")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CementPrice).HasColumnName("cement_price");

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

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Factory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("product_factory_id_fk");

                entity.HasOne(d => d.Transporter)
                    .WithMany(p => p.Factory)
                    .HasForeignKey(d => d.TransporterId)
                    .HasConstraintName("transporter_factory_id_fk");
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
                    .HasColumnType("varchar(1000)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idinvoice)
                    .HasName("PRIMARY");

                entity.ToTable("invoice");

                entity.HasIndex(e => e.FactoryId)
                    .HasName("FactoryId_idx");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("ProjectId_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id_idx");

                entity.Property(e => e.Idinvoice).HasColumnName("idinvoice");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FullCost).HasDefaultValueSql("'0'");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RemainForCustomer)
                    .HasColumnName("remainForCustomer")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RemainForYamama)
                    .HasColumnName("remainForYamama")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.FactoryId)
                    .HasConstraintName("FactoryId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("ProjectId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_invoice_id_fk");
            });

            modelBuilder.Entity<LinkRQA>(entity =>
            {
                entity.HasKey(e => e.IdlinkRQA)
                    .HasName("PRIMARY");

                entity.ToTable("link_r_q_a");

                entity.HasIndex(e => e.AnswerId)
                    .HasName("answer_id_idx");

                entity.HasIndex(e => e.QId)
                    .HasName("question_id_idx");

                entity.HasIndex(e => e.ReportId)
                    .HasName("report_id_idx");

                entity.Property(e => e.IdlinkRQA).HasColumnName("idlink_r_q_a");

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.QId).HasColumnName("q_Id");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.LinkRQA)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("answer_id");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.LinkRQA)
                    .HasForeignKey(d => d.QId)
                    .HasConstraintName("q_Id");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.LinkRQA)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("report_id");
            });

            modelBuilder.Entity<MoneyDelivered>(entity =>
            {
                entity.HasKey(e => e.IdmoneyDelivered)
                    .HasName("PRIMARY");

                entity.ToTable("money_delivered");

                entity.HasIndex(e => e.FId)
                    .HasName("factory_id_idx");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id_idx");

                entity.HasIndex(e => e.PId)
                    .HasName("p_id_idx");

                entity.Property(e => e.IdmoneyDelivered).HasColumnName("idmoney_delivered");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FirstDate)
                    .HasColumnName("first_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.MoneyDelivered)
                    .HasForeignKey(d => d.FId)
                    .HasConstraintName("f_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.MoneyDelivered)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("invoice_id");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.MoneyDelivered)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("p_id");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Idnotification)
                    .HasName("PRIMARY");

                entity.ToTable("notification");

                entity.HasIndex(e => e.ReceiverId)
                    .HasName("receiver-id_idx");

                entity.HasIndex(e => e.SenderId)
                    .HasName("sender-id_idx");

                entity.Property(e => e.Idnotification).HasColumnName("idnotification");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ReceiverId)
                    .HasColumnName("receiver-id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SenderId)
                    .HasColumnName("sender-id")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.NotificationReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("reciever_not_id");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.NotificationSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("sender_not_id");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Idphoto)
                    .HasName("PRIMARY");

                entity.ToTable("photo");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.Idphoto).HasColumnName("idphoto");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.ProjectId)
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

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(e => e.Idproduction)
                    .HasName("PRIMARY");

                entity.ToTable("production");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("product_id_idx");

                entity.Property(e => e.Idproduction).HasColumnName("idproduction");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("IdProduct");
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

                entity.Property(e => e.Cost).HasColumnName("cost");

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

            modelBuilder.Entity<QModelNames>(entity =>
            {
                entity.HasKey(e => e.IdqModelNames)
                    .HasName("PRIMARY");

                entity.ToTable("q_model_names");

                entity.Property(e => e.IdqModelNames).HasColumnName("idq_model_names");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(1000)");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.IdQuestions)
                    .HasName("PRIMARY");

                entity.ToTable("questions");

                entity.HasIndex(e => e.ModelName)
                    .HasName("model_name_idx");

                entity.Property(e => e.IdQuestions).HasColumnName("idQuestions");

                entity.Property(e => e.ModelName).HasColumnName("model_name");

                entity.Property(e => e.QuestionText)
                    .HasColumnName("question_text")
                    .HasColumnType("text");

                entity.HasOne(d => d.ModelNameNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ModelName)
                    .HasConstraintName("model_name");
            });

            modelBuilder.Entity<RequestInformation>(entity =>
            {
                entity.HasKey(e => e.IdrequestInformation)
                    .HasName("PRIMARY");

                entity.ToTable("request_information");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.RecieverId)
                    .HasName("reciever_id");

                entity.HasIndex(e => e.SenderId)
                    .HasName("sender_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.IdrequestInformation).HasColumnName("idrequest_information");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.RecieverId)
                    .HasColumnName("reciever_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SenderId)
                    .HasColumnName("sender_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.RequestInformation)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("file_id_info_fk");

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.RequestInformationReciever)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("reciever_info_fk");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.RequestInformationSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("sender_info_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.RequestInformation)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("task_id_info_fk");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Idstore)
                    .HasName("PRIMARY");

                entity.ToTable("store");

                entity.HasIndex(e => e.ProId)
                    .HasName("product_id");

                entity.Property(e => e.Idstore).HasColumnName("idstore");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_store");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.HasKey(e => e.Idtarget)
                    .HasName("PRIMARY");

                entity.ToTable("target");

                entity.HasIndex(e => e.SalesmanId)
                    .HasName("salesmanId_idx");

                entity.Property(e => e.Idtarget).HasColumnName("idtarget");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Sales).HasColumnName("sales");

                entity.Property(e => e.SalesmanId)
                    .HasColumnName("salesmanId")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Visits).HasColumnName("visits");

                entity.HasOne(d => d.Salesman)
                    .WithMany(p => p.Target)
                    .HasForeignKey(d => d.SalesmanId)
                    .HasConstraintName("salesmanId_fk");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Idtask)
                    .HasName("PRIMARY");

                entity.ToTable("task");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("creator_id");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id_idx");

                entity.HasIndex(e => e.PhotoId)
                    .HasName("photo_id_idx");

                entity.HasIndex(e => e.ResponsibleId)
                    .HasName("responsible_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Idtask).HasColumnName("idtask");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.ResponsibleId)
                    .HasColumnName("responsible_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TaskCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("task_creator_fk");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("file_id");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("photo_id");

                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.TaskResponsible)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("task_responsible_fk");

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

                entity.Property(e => e.TransporterNum)
                    .HasColumnName("transporter_num")
                    .HasColumnType("varchar(50)");
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

                entity.Property(e => e.Gifts).HasColumnName("gifts");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("varchar(255)");

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
                    .HasConstraintName("user_visit_fk");
            });
        }
    }
}
