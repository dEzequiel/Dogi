﻿using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records eqivalent to IndividualProceedingStatus domain enumerator.
    /// </summary>
    public class IndividualProceedingStatus : SupportTable
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ICollection<IndividualProceeding>? Processees { get; set; }
        public virtual IndividualProceeding? IndividualProceeding { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public IndividualProceedingStatus(int id, string status) : base(id)
        {
            Status = status;
        }

        public IndividualProceedingStatus(int id) : base(id) { }
    }
}
