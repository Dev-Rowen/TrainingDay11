namespace dal
{
    using System;
    using dal.models;
    using Microsoft.EntityFrameworkCore;

    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
        public DbSet<Patient> Patients { get; set; }
    }
}