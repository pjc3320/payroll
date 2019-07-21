namespace Payroll.Application.Models
{
    public abstract class Person : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public abstract double BenefitCost { get; }
    }
}
