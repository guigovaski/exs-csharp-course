using System.Globalization;
using ExPayment.Services;
using System.Text;

namespace ExPayment.Entities
{
    internal class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        private List<Installment> _installmentList = new List<Installment>();
        private IServicePayment _servicePayment;
        public Contract() { }

        public Contract(int number, DateTime date, double totalValue, int n, IServicePayment servicePayment)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            _servicePayment = servicePayment;
            AddInstallments(n);
        }

        public void AddInstallments(int n)
        {
            if (n >= 1)
            {
                double installmentValue = TotalValue / n;
                for (int i = 1; i <= n; i++)
                {
                    DateTime date = Date.AddMonths(i);
                    double tax = _servicePayment.Tax(installmentValue);
                    _installmentList.Add(new Installment(date, tax));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Installment i in _installmentList)
            {
                sb.Append(i.DueDate.ToShortDateString());
                sb.Append(" - ");
                sb.AppendLine(i.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

    }
}
