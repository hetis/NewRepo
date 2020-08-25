using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class CMContext : DbContext
    {
        public CMContext()
        {
        }

        public CMContext(DbContextOptions<CMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<CallHistory> CallHistories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientContactInfoComp> ClientContactInfoComps { get; set; }
        public virtual DbSet<ClientRef> ClientRefs { get; set; }
        public virtual DbSet<ClientRelationComp> ClientRelationComps { get; set; }
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<CodeType> CodeTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentComp> CommentComps { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Hash> Hashes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobParameter> JobParameters { get; set; }
        public virtual DbSet<JobQueue> JobQueues { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Naming> Namings { get; set; }
        public virtual DbSet<OtherAsset> OtherAssets { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPeople { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PropertyAsset> PropertyAssets { get; set; }
        public virtual DbSet<Queue> Queues { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<VehicleAsset> VehicleAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(50)
                    .HasColumnName("additional_info");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryQl).HasColumnName("country_ql");

                entity.Property(e => e.DistrictOrStreet)
                    .HasMaxLength(50)
                    .HasColumnName("district_or_street");

                entity.Property(e => e.DistrictOrStreetQl).HasColumnName("district_or_street_ql");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.RegOrCityId).HasColumnName("reg_or_city_id");

                entity.Property(e => e.RegOrCityQl).HasColumnName("reg_or_city_ql");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_ClientRef");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(x => x.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(x => x.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Assets", "Composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.ObjectIdentifier).HasColumnName("object_identifier");

                entity.Property(e => e.ObjectIdentifierSourceType).HasColumnName("object_identifier_source_type");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_ClientRef");
            });

            modelBuilder.Entity<CallHistory>(entity =>
            {
                entity.ToTable("CallHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("call_timestamp")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ContactInfoId).HasColumnName("contact_info_id");

                entity.Property(e => e.Direction)
                    .HasMaxLength(15)
                    .HasColumnName("direction");

                entity.Property(e => e.ResponsibleNumner)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("responsible_numner");

                entity.HasOne(d => d.ContactInfo)
                    .WithMany(p => p.CallHistories)
                    .HasForeignKey(x => x.ContactInfoId)
                    .HasConstraintName("FK_CallHistory_ContactInfo");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientType).HasColumnName("client_type");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Client");
            });

            modelBuilder.Entity<ClientContactInfoComp>(entity =>
            {
                entity.ToTable("ClientContactInfoComp", "Composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactInfoId).HasColumnName("contact_info_id");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.ContactInfo)
                    .WithMany(p => p.ClientContactInfoComps)
                    .HasForeignKey(x => x.ContactInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactInfo_ContactInfo1");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.ClientContactInfoComps)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientContactInfoComp_ClientRef");
            });

            modelBuilder.Entity<ClientRef>(entity =>
            {
                entity.HasKey(x => x.Inn);

                entity.ToTable("ClientRef");

                entity.Property(e => e.Inn).HasColumnName("inn");
            });

            modelBuilder.Entity<ClientRelationComp>(entity =>
            {
                entity.ToTable("ClientRelationComp", "Composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Client1).HasColumnName("client_1");

                entity.Property(e => e.Client2).HasColumnName("client_2");

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.HasOne(d => d.Client1Navigation)
                    .WithMany(p => p.ClientRelationCompClient1Navigations)
                    .HasForeignKey(x => x.Client1)
                    .HasConstraintName("FK_ClientRelationComp_ClientRef");

                entity.HasOne(d => d.Client2Navigation)
                    .WithMany(p => p.ClientRelationCompClient2Navigations)
                    .HasForeignKey(x => x.Client2)
                    .HasConstraintName("FK_ClientRelationComp_ClientRef1");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.ToTable("Code", "Classifier");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodeOid).HasColumnName("code_oid");

                entity.Property(e => e.TypeOid).HasColumnName("type_oid");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");

                entity.HasOne(d => d.TypeO)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(x => x.TypeOid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Code_CodeType");
            });

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.ToTable("CodeType", "Classifier");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("create_timestamp")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Creator)
                    .HasMaxLength(34)
                    .HasColumnName("creator");

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<CommentComp>(entity =>
            {
                entity.ToTable("CommentComp", "Composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentComps)
                    .HasForeignKey(x => x.CommentId)
                    .HasConstraintName("FK_CommentComp_Comment");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CommentComps)
                    .HasForeignKey(x => x.ContactId)
                    .HasConstraintName("FK_CommentComp_ContactInfo");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.CommentComps)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentComp_ClientRef");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyNameQl).HasColumnName("company_name_ql");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_ClientRef");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("ContactInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(x => x.Key, "CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("document_expire_date")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.DocumentType).HasColumnName("document_type");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_ClientRef");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(x => new { x.Key, x.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(x => x.ExpireAt, "IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(x => new { x.StateName, x.ExpireAt }, "IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(x => x.StateName, "IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ExpireAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(x => new { x.JobId, x.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameters)
                    .HasForeignKey(x => x.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(x => new { x.Queue, x.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(x => new { x.Key, x.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(x => x.ExpireAt, "IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<Naming>(entity =>
            {
                entity.ToTable("Naming");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DefaultValue)
                    .HasMaxLength(34)
                    .HasColumnName("default_value");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.ValueEn)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("value_en");

                entity.Property(e => e.ValueRu)
                    .HasMaxLength(34)
                    .HasColumnName("value_ru");
            });

            modelBuilder.Entity<OtherAsset>(entity =>
            {
                entity.ToTable("OtherAsset");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<PhysicalPerson>(entity =>
            {
                entity.ToTable("PhysicalPerson");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birth_date")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.BirthDateQl).HasColumnName("birth_date_ql");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(34)
                    .HasColumnName("father_name");

                entity.Property(e => e.FatherNameQl).HasColumnName("father_name_ql");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(34)
                    .HasColumnName("first_name");

                entity.Property(e => e.FirstNameQl).HasColumnName("first_name_ql");

                entity.Property(e => e.FullName)
                    .HasMaxLength(108)
                    .HasColumnName("full_name");

                entity.Property(e => e.FullNameQl).HasColumnName("full_name_ql");

                entity.Property(e => e.Inn).HasColumnName("inn");

                entity.Property(e => e.LastName)
                    .HasMaxLength(34)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastNameQl).HasColumnName("last_name_ql");

                entity.Property(e => e.MonthlyIncome)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("monthly_income")
                    .HasAnnotation("Relational:ColumnType", "decimal(12, 2)");

                entity.Property(e => e.MonthlyIncomeQl).HasColumnName("monthly_income_ql");

                entity.Property(e => e.Pin)
                    .HasMaxLength(10)
                    .HasColumnName("pin")
                    .IsFixedLength(true);

                entity.Property(e => e.PinQl).HasColumnName("pin_ql");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.PositionCustom)
                    .HasMaxLength(250)
                    .HasColumnName("position_custom");

                entity.Property(e => e.PositionQl).HasColumnName("position_ql");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.InnNavigation)
                    .WithMany(p => p.PhysicalPeople)
                    .HasForeignKey(x => x.Inn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicalPerson_Position");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position", "Classifier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(25)
                    .HasColumnName("category")
                    .IsFixedLength(true);

                entity.Property(e => e.PositionName)
                    .HasMaxLength(25)
                    .HasColumnName("position_name")
                    .IsFixedLength(true);

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<PropertyAsset>(entity =>
            {
                entity.ToTable("PropertyAsset");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.ToTable("Queue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("created_timestamp")
                    .HasDefaultValueSql("(getdate())")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastErrorText).HasColumnName("last_error_text");

                entity.Property(e => e.LastProcessedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("last_processed_on")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Payload)
                    .HasColumnType("xml")
                    .HasColumnName("payload")
                    .HasAnnotation("Relational:ColumnType", "xml");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProcessAfter)
                    .HasColumnType("datetime")
                    .HasColumnName("process_after")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Recipient)
                    .HasMaxLength(256)
                    .HasColumnName("recipient");

                entity.Property(e => e.RelatedObjectId).HasColumnName("related_object_id");

                entity.Property(e => e.RetryCount).HasColumnName("retry_count");

                entity.Property(e => e.StatusOid).HasColumnName("status_oid");

                entity.Property(e => e.SubtypeOid).HasColumnName("subtype_oid");

                entity.Property(e => e.SystemOid).HasColumnName("system_oid");

                entity.Property(e => e.TypeOid).HasColumnName("type_oid");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.ToTable("Relation", "Classifier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("date_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("date_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Reverse)
                    .HasMaxLength(50)
                    .HasColumnName("reverse");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(x => x.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(x => x.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(x => new { x.Key, x.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(x => x.ExpireAt, "IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(x => new { x.Key, x.Score }, "IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.ToTable("Source", "Classifier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.ParamsJson).HasColumnName("params_json");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("valid_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(x => new { x.JobId, x.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.States)
                    .HasForeignKey(x => x.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "Composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("date_from")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("date_to")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.ObjectIdentifier).HasColumnName("object_identifier");

                entity.Property(e => e.ObjectIdentifierSourceType)
                    .HasMaxLength(50)
                    .HasColumnName("object_identifier_source_type");

                entity.Property(e => e.QualityPoint).HasColumnName("quality_point");

                entity.Property(e => e.TagId).HasColumnName("tag_id");
            });

            modelBuilder.Entity<VehicleAsset>(entity =>
            {
                entity.ToTable("VehicleAsset");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
