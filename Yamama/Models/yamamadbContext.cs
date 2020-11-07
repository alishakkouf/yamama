﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Yamama.Models
{
    public partial class yamamadbContext : DbContext
    {
        //public yamamaContext()
        //{
        //}

        public yamamadbContext(DbContextOptions<yamamadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualIntencive> ActualIntencive { get; set; }
        public virtual DbSet<ActualNeeds> ActualNeeds { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<ExpectedIntencive> ExpectedIntencive { get; set; }
        public virtual DbSet<ExpectedNeeds> ExpectedNeeds { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<RequestInformation> RequestInformation { get; set; }
        public virtual DbSet<MoneyDelivered> MoneyDelivered { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<LinkRQA> LinkRQA { get; set; }
         public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<CustomerSatisfactionReports> CustomerSatisfactionReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=yamama;UID=root;PWD=batoolhammoud95_mysql;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualIntencive>(entity =>
            {
                entity.HasKey(e => e.IdactualIntencive)
                    .HasName("PRIMARY");

                entity.ToTable("actual_intencive");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_actual_intencive_id_idx");

                entity.Property(e => e.IdactualIntencive).HasColumnName("idactual_intencive");

                entity.Property(e => e.ActualIntencive1).HasColumnName("actual_intencive");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

            
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

            modelBuilder.Entity<ActualNeeds>(entity =>
            {
                entity.HasKey(e => e.IdactualNeeds)
                    .HasName("PRIMARY");

                entity.ToTable("actual_needs");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id_idx");

                entity.Property(e => e.IdactualNeeds).HasColumnName("idactual_needs");

                entity.Property(e => e.ActualNeeds1).HasColumnName("actual_needs");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ActualNeeds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_actual_needs_id");
            });

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

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PRIMARY");

                entity.ToTable("cart");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.IdCart).HasColumnName("idcart");

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

            modelBuilder.Entity<ExpectedIntencive>(entity =>
            {
                entity.HasKey(e => e.IdexpectedIntencive)
                    .HasName("PRIMARY");

                entity.ToTable("expected_intencive");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_expected_intencive_idx");

                entity.Property(e => e.IdexpectedIntencive).HasColumnName("idexpected_intencive");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpectedIntencive1).HasColumnName("expected_intencive");

                entity.Property(e => e.UserId).HasColumnName("user_id");

               
            });

            modelBuilder.Entity<ExpectedNeeds>(entity =>
            {
                entity.HasKey(e => e.IdexptedNeeds)
                    .HasName("PRIMARY");

                entity.ToTable("expected_needs");

                entity.HasIndex(e => e.ProductId)
                    .HasName("prod_actual_needs_idx");

                entity.Property(e => e.IdexptedNeeds).HasColumnName("idexpted_needs");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpectedNeeds1).HasColumnName("expected_needs");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ExpectedNeeds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("prod_actual_needs");
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

                //entity.HasIndex(e => e.Salesman)
                //    .HasName("salesman_invoice_fk_idx");

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

                //entity.Property(e => e.Salesman).HasColumnName("salesman");

                //entity.Property(e => e.Supplier)
                //    .HasColumnName("supplier")
                //    .HasColumnType("varchar(100)");

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

                //entity.HasOne(d => d.SalesmanNavigation)
                //    .WithMany(p => p.Invoice)
                //    .HasForeignKey(d => d.Salesman)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("salesman_invoice_fk");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Idnotification)
                    .HasName("PRIMARY");

                entity.ToTable("notification");

                entity.HasIndex(e => e.RecieverId)
                    .HasName("user_reciever_idx");

                entity.HasIndex(e => e.SenderId)
                    .HasName("user_sender_idx");

                entity.Property(e => e.Idnotification).HasColumnName("idnotification");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("longtext");

                entity.Property(e => e.RecieverId).HasColumnName("reciever-id");

                entity.Property(e => e.SenderId).HasColumnName("sender-id");

                //entity.HasOne(d => d.Reciever)
                //    .WithMany(p => p.NotificationReciever)
                //    .HasForeignKey(d => d.RecieverId)
                //    .HasConstraintName("user_reciever");

                //entity.HasOne(d => d.Sender)
                //    .WithMany(p => p.NotificationSender)
                //    .HasForeignKey(d => d.SenderId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("user_sender");
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
            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.IdQuestions)
                    .HasName("PRIMARY");

                entity.ToTable("questions");

                entity.Property(e => e.IdQuestions).HasColumnName("idQuestions");

                entity.Property(e => e.QuestionText)
                    .HasColumnName("question_text")
                    .HasColumnType("text");
            });


            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Idstore)
                    .HasName("PRIMARY");

                entity.ToTable("store");

                entity.HasIndex(e => e.Idstore)
                    .HasName("idstor_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Idstore).HasColumnName("idstor");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("store_product_id_fk");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.HasKey(e => e.Idtarget)
                    .HasName("PRIMARY");

                entity.ToTable("target");

                entity.HasIndex(e => e.SalesmanId)
                    .HasName("user_salesman_id_idx");

                entity.Property(e => e.Idtarget).HasColumnName("idtarget");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Sales).HasColumnName("sales");

                entity.Property(e => e.SalesmanId).HasColumnName("salesmanId");

                entity.Property(e => e.Visits).HasColumnName("visits");

                //entity.HasOne(d => d.SalesmanId)
                //    .WithMany(p => p.Target)
                //    .HasForeignKey(d => d.SalesmanId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("user_salesman_id");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Idtask)
                    .HasName("PRIMARY");

                entity.ToTable("task");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_task_fk_idx");

                entity.HasIndex(e => e.PhotoId)
                    .HasName("photo_task_fk_idx");

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

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                //entity.HasOne(d => d.File)
                //    .WithMany(p => p.Task)
                //    .HasForeignKey(d => d.FileId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("file_task_fk");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("photo_task_fk");

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

                //entity.Property(e => e.Gifts).HasColumnName("gifts");

                //entity.Property(e => e.Notes)
                //    .HasColumnName("notes")
                //    .HasColumnType("varchar(45)");

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

          
            });
        }
    }
}
