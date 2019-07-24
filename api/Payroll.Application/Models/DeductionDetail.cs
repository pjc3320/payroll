namespace Payroll.Application.Models
{
    public class DeductionDetail
    {
        public double AnnualSalary { get; set; }

        public double PeriodSalary { get; set; }

        public double AnnualDeductions { get; set; }

        public double PeriodDeductions { get; set; }
    }
}
