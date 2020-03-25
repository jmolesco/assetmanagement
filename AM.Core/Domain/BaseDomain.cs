using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain
{

    /// <summary>
    /// Base class for domain classes
    /// </summary>
    public abstract class BaseDomain
    {

        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

    }
}
