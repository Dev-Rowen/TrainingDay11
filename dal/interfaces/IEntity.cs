namespace dal.interfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IEntity
    {
        [Timestamp]
        byte[] RowVersion { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        string CreatedBy { get; set; }
    }
    public interface IEntity<T> : IEntity
    {
        T Id {get; set;}
    }
} 