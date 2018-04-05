namespace dal.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using dal.interfaces;

    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "SYSTEM";
    }
}