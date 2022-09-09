namespace ExTaxes.Entities
{
    internal class NaturalPayer : Payer
    {
        public double HealthExpenses { get; set; }

        public NaturalPayer() { }

        public NaturalPayer(double healthExpenses, string name, double annualIncome) : base(name, annualIncome)
        {
            HealthExpenses = healthExpenses;
        }

        public override double TotalTaxes()
        {
           double totalTaxes;

           if (AnnualIncome < 20000)
           {
                totalTaxes = 0.15 * AnnualIncome;
           }
           else
           {
                totalTaxes = 0.25 * AnnualIncome;
           }

           if (HealthExpenses > 0)
           {
               return totalTaxes + (HealthExpenses * 0.5);
           }
           else
           {
               return totalTaxes;
           }
        }
    }
}
