using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.ValueObjects
{
    public class PersonBannedInformation : ValueObject
    {
        public string PersonIdentifierId {get; set;}= null!;
        public string? Observations { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PersonIdentifierId;
            yield return Observations;
            yield return Created;
            yield return CreatedBy;
        }
    }
}