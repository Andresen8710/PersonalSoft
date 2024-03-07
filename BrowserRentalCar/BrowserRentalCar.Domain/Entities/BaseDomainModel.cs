using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Domain.Entities
{
    public abstract class BaseDomainModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateTime CreationDate { get; set; }
        public string? CreateBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; } = string.Empty;
    }
}
