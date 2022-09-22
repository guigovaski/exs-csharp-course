namespace ExPayment.Services
{
    internal class PaypalService : IServicePayment
    {
        public double Tax(double amount)
        {
            double tax = amount * 0.03;
            return amount + tax;
        }
    }
}
