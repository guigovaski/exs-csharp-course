using System.Globalization;

namespace ExProducts.Entities
{
    internal class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct() { }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public override string PriceTag()
        {
            return base.PriceTag() + TotalPrice().ToString("F2", CultureInfo.InvariantCulture);
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
    }
}
