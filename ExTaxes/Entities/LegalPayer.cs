namespace ExTaxes.Entities
{
    internal class LegalPayer : Payer
    {
        public int EmployeesNumber { get; set; }
        
        public LegalPayer() { }

        public LegalPayer(int employeesNumber, string name, double annualIncome)
        {
            EmployeesNumber = employeesNumber;
        }

        public override double TotalTaxes()
        {
            if (EmployeesNumber > 10)
            {
                return AnnualIncome * 0.14;
            }
            else
            {
                return AnnualIncome * 0.16;
            }
        }
    }
}
