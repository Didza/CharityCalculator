using System;

namespace CharityCalculator.Domain.Models.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public BaseEntity(Guid? id = null, DateTime? dateCreated = null, DateTime? lastModified = null)
        {
            Id = id ?? Guid.NewGuid();
            DateCreated = dateCreated ?? DateTime.Now;
            LastModified = lastModified ?? DateTime.Now;
        }
    }
}
