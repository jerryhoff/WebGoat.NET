using System.Data.Entity;

namespace OWASP.WebGoat.NET.Entities
{
    public partial class CoinsDB : DbContext
    {
        public CoinsDB()
            : base("name=CoinsDB")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CustomerLogin> CustomerLogin { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SecurityQuestions> SecurityQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.catName)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.productCode)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerLogin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerLogin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerLogin>()
                .Property(e => e.answer)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.logoFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.contactLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.contactFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.addressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.addressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.postalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.extension)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.officeCode)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.jobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.officeCode)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.addressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.addressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.postalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Offices>()
                .Property(e => e.territory)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.productCode)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.cardType)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.creditCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.cardExpirationMonth)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.cardExpirationYear)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.confirmationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.productCode)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.productName)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.productImage)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.productVendor)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestions>()
                .Property(e => e.question_text)
                .IsUnicode(false);
        }
    }
}
