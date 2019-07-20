using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public class Dependent : Person
    {
        private const int BenefitCost = 500;

        public Relationship Relationship { get; set; }
    }
}
