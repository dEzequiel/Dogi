using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Support
{
    /// <summary>
    /// Support table representing records eqivalent to IndividualProceedingStatus domain enumerator.
    /// </summary>
    public class ProceedingStatus : SupportTable
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public ProceedingStatus(int id, string status) : base(id)
        {
            Status = status;
        }
    }
}
