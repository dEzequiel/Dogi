using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscuting.Api.DTOs
{
    /// <summary>
    /// Represents the animal shelter worker.
    /// </summary>
    public class AdminData
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
    }
}
