using EntityObjects.Attributes;
using EntityObjects.UtilityObjects;
using System;

namespace EntityObjects.Objects
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = 1;//System
            this.Status = EntityStatus.active;
        }

        public Int32 ID { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }

        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public EntityStatus Status { get; set; }
    }
}