using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManager.Domain.Common
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>, ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        DateTimeOffset? ICreatedByEntity.CreatedOn { get; set; }
    }
}