


using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Model;


namespace ProjectArti.Api.Data
{
    public class My_dbContext : DbContext
    {



        public My_dbContext(DbContextOptions<My_dbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Property>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Property>().Property(x=>x.Price).HasColumnType("decimal(18,2)").IsRequired();
            modelBuilder.Entity<PropertyType>().Property(x=>x.Price).HasColumnType("decimal(18,2)").IsRequired();
           
             

         



        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskArti> taskArtis { get; set; }
        public DbSet<Profile> profiles { get; set; }

        public DbSet<Property> properties { get; set; }
       
        public DbSet<RequestClient> requestClients { get; set; }
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Craftsman> craftsmens { get; set; }
        public DbSet<JobApplication> jobApplications { get; set; }
        public DbSet<BaseRating> BaseRating { get; set; } 
        public DbSet<BusinessType> BusinessType { get; set; } 
        public DbSet<PropertyType> PropertyType { get; set; } = default!;
        public DbSet<FloorType> FloorType { get; set; } = default!;
        public DbSet<CommercialType> CommercialType { get; set; } = default!;
        public DbSet<Parking> Parking { get; set; } = default!;
        public DbSet<GardenType> GardenType { get; set; } = default!;
        public DbSet<SwimmingPoolT> SwimmingPoolT { get; set; } = default!;
        public DbSet<Garage> Garage { get; set; } = default!;
        public DbSet<Balcony> Balcony { get; set; } = default!;
        public DbSet<GymTop> GymTop { get; set; } = default!;
        public DbSet<MeetingRoom> MeetingRoom { get; set; } = default!;
        public DbSet<RecreationalArea> RecreationalArea { get; set; } = default!;
        public DbSet<PendingStatus> PendingStatus { get; set; } = default!;
        public DbSet<RentedStatus> RentedStatus { get; set; } = default!;
        public DbSet<SoldStatus> SoldStatus { get; set; } = default!;
        public DbSet<AvailableStatus> AvailableStatus { get; set; } = default!;
        public DbSet<UnderRenovationStatus> UnderRenovationStatus { get; set; } = default!;
       

    }

}