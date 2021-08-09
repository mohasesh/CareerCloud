using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess.CareerCloudEntityFrameworkDataAccess
{
    public partial class CareerCloudContext : DbContext
    {
        public CareerCloudContext()
        {
        }

        public CareerCloudContext(DbContextOptions<CareerCloudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public virtual DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual DbSet<CompanyJobDescriptionPoco> CompanyJobsDescriptions { get; set; }
        public virtual DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public virtual DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public virtual DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public virtual DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public virtual DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public virtual DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public virtual DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MOHAMMEDADEM_PC\\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicantEducationPoco>(entity =>
            {
                entity.ToTable("Applicant_Educations");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CertificateDiploma)
                    .HasMaxLength(100)
                    .HasColumnName("Certificate_Diploma");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("date")
                    .HasColumnName("Completion_Date");

                entity.Property(e => e.CompletionPercent).HasColumnName("Completion_Percent");

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantEducations)
                    .HasForeignKey(d => d.Applicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Educations_Applicant_Profiles");
            });

            modelBuilder.Entity<ApplicantJobApplicationPoco>(entity =>
            {
                entity.ToTable("Applicant_Job_Applications");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApplicationDate)
                    .HasColumnName("Application_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantJobApplications)
                    .HasForeignKey(d => d.Applicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Job_Applications_Applicant_Profiles");

                entity.HasOne(d => d.CompanyJob)
                    .WithMany(p => p.ApplicantJobApplications)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Job_Applications_Company_Jobs");
            });

            modelBuilder.Entity<ApplicantProfilePoco>(entity =>
            {
                entity.ToTable("Applicant_Profiles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("City_Town");

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Country_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CurrentRate)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Current_Rate");

                entity.Property(e => e.CurrentSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Current_Salary");

                entity.Property(e => e.Province)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("State_Province_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .HasColumnName("Street_Address");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Zip_Postal_Code")
                    .IsFixedLength(true);

                entity.HasOne(d => d.SystemCountryCode)
                    .WithMany(p => p.ApplicantProfiles)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_Applicant_Profiles_System_Country_Codes");

                entity.HasOne(d => d.SecurityLogins)
                    .WithMany(p => p.ApplicantProfiles)
                    .HasForeignKey(d => d.Login)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Profiles_Security_Logins");
            });

            modelBuilder.Entity<ApplicantResumePoco>(entity =>
            {
                entity.ToTable("Applicant_Resumes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("Last_Updated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Resume).IsRequired();

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantResumes)
                    .HasForeignKey(d => d.Applicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Resumes_Applicant_Profiles");
            });

            modelBuilder.Entity<ApplicantSkillPoco>(entity =>
            {
                entity.ToTable("Applicant_Skills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndMonth).HasColumnName("End_Month");

                entity.Property(e => e.EndYear).HasColumnName("End_Year");

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SkillLevel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Skill_Level")
                    .IsFixedLength(true);

                entity.Property(e => e.StartMonth).HasColumnName("Start_Month");

                entity.Property(e => e.StartYear).HasColumnName("Start_Year");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantSkills)
                    .HasForeignKey(d => d.Applicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Skills_Applicant_Profiles");
            });

            modelBuilder.Entity<ApplicantWorkHistoryPoco>(entity =>
            {
                entity.ToTable("Applicant_Work_History");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Country_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.EndMonth).HasColumnName("End_Month");

                entity.Property(e => e.EndYear).HasColumnName("End_Year");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("Job_Description");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Job_Title");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartMonth).HasColumnName("Start_Month");

                entity.Property(e => e.StartYear).HasColumnName("Start_Year");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantWorkHistorys)
                    .HasForeignKey(d => d.Applicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Work_Experiences_Applicant_Profiles");

                entity.HasOne(d => d.SystemCountryCode)
                    .WithMany(p => p.ApplicantWorkHistorys)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_Work_History_System_Country_Codes");
            });

            modelBuilder.Entity<CompanyDescriptionPoco>(entity =>
            {
                entity.ToTable("Company_Descriptions");

                entity.HasIndex(e => new { e.Company, e.LanguageId }, "IX_UNQ_Company_Descriptions")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Company_Description");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LanguageID")
                    .IsFixedLength(true);

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.CompanyProfile)
                    .WithMany(p => p.CompanyDescriptions)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Descriptions_Company_Profiles");

                entity.HasOne(d => d.SystemLanguageCode)
                    .WithMany(p => p.CompanyDescriptions)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Descriptions_System_Language_Codes");
            });

            modelBuilder.Entity<CompanyJobPoco>(entity =>
            {
                entity.ToTable("Company_Jobs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsCompanyHidden).HasColumnName("Is_Company_Hidden");

                entity.Property(e => e.IsInactive).HasColumnName("Is_Inactive");

                entity.Property(e => e.ProfileCreated).HasColumnName("Profile_Created");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.CompanyProfile)
                    .WithMany(p => p.CompanyJobs)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Jobs_Company_Profiles");
            });

            modelBuilder.Entity<CompanyJobEducationPoco>(entity =>
            {
                entity.ToTable("Company_Job_Educations");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.CompanyJob)
                    .WithMany(p => p.CompanyJobEducations)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Job_Educations_Company_Jobs");
            });

            modelBuilder.Entity<CompanyJobSkillPoco>(entity =>
            {
                entity.ToTable("Company_Job_Skills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SkillLevel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Skill_Level");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.CompanyJob)
                    .WithMany(p => p.CompanyJobSkills)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Job_Skills_Company_Jobs");
            });

            modelBuilder.Entity<CompanyJobDescriptionPoco>(entity =>
            {
                entity.ToTable("Company_Jobs_Descriptions");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.JobDescriptions)
                    .HasMaxLength(1000)
                    .HasColumnName("Job_Descriptions");

                entity.Property(e => e.JobName)
                    .HasMaxLength(100)
                    .HasColumnName("Job_Name");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.CompanyJob)
                    .WithMany(p => p.CompanyJobDescriptions)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Jobs_Descriptions_Company_Jobs");
            });

            modelBuilder.Entity<CompanyLocationPoco>(entity =>
            {
                entity.ToTable("Company_Locations");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("City_Town");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Country_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.Province)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("State_Province_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .HasColumnName("Street_Address");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Zip_Postal_Code")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CompanyProfile)
                    .WithMany(p => p.CompanyLocations)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Locations_Company_Profiles");
                entity.HasOne(d => d.SystemCountryCode)
                    .WithMany(p => p.CompanyLocations)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Locations_System_Country_Codes");
            });

            modelBuilder.Entity<CompanyProfilePoco>(entity =>
            {
                entity.ToTable("Company_Profiles");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyLogo).HasColumnName("Company_Logo");

                entity.Property(e => e.CompanyWebsite)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_Website");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Contact_Phone");

                entity.Property(e => e.RegistrationDate).HasColumnName("Registration_Date");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");
            });

            modelBuilder.Entity<SecurityLoginPoco>(entity =>
            {
                entity.ToTable("Security_Logins");

                entity.HasIndex(e => e.Login, "IX_UNQ_Security_Logins")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AgreementAccepted).HasColumnName("Agreement_Accepted_Date");

                entity.Property(e => e.Created).HasColumnName("Created_Date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_Address");

                entity.Property(e => e.ForceChangePassword).HasColumnName("Force_Change_Password");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.IsInactive).HasColumnName("Is_Inactive");

                entity.Property(e => e.IsLocked).HasColumnName("Is_Locked");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUpdate).HasColumnName("Password_Update_Date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.PrefferredLanguage)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Prefferred_Language")
                    .IsFixedLength(true);

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");
            });

            modelBuilder.Entity<SecurityLoginsLogPoco>(entity =>
            {
                entity.ToTable("Security_Logins_Log");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsSuccesful).HasColumnName("Is_Succesful");

                entity.Property(e => e.LogonDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Logon_Date");

                entity.Property(e => e.SourceIP)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Source_IP")
                    .IsFixedLength(true);

                entity.HasOne(d => d.SecurityLogin)
                    .WithMany(p => p.SecurityLoginsLogs)
                    .HasForeignKey(d => d.Login)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Logins_Log_Security_Logins");
            });

            modelBuilder.Entity<SecurityLoginsRolePoco>(entity =>
            {
                entity.ToTable("Security_Logins_Roles");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Time_Stamp");

                entity.HasOne(d => d.SecurityLogin)
                    .WithMany(p => p.SecurityLoginsRoles)
                    .HasForeignKey(d => d.Login)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Logins_Roles_Security_Logins");

                entity.HasOne(d => d.SecurityRole)
                    .WithMany(p => p.SecurityLoginsRoles)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Logins_Roles_Security_Roles");
            });

            modelBuilder.Entity<SecurityRolePoco>(entity =>
            {
                entity.ToTable("Security_Roles");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsInactive).HasColumnName("Is_Inactive");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemCountryCodePoco>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("System_Country_Codes");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemLanguageCodePoco>(entity =>
            {
                entity.HasKey(e => e.LanguageID)
                    .HasName("PK_Culture_CultureID");

                entity.ToTable("System_Language_Codes");

                entity.Property(e => e.LanguageID)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LanguageID")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NativeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Native_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
