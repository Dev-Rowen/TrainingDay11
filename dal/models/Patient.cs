namespace dal.models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using dal.Abstracts;

    public class Patient : Entity<int>
    {
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}