using ExOrder.Entities.Enums;
using System.Text;

namespace ExOrder.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        private static List<OrderItem> ListItem = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public static void AddItem(OrderItem item)
        {
            Order.ListItem.Add(item);
        }

        public static void RemoveItem(OrderItem item)
        {
            ListItem.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in ListItem)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("ORDER SUMMARY:");
            str.Append("Order Moment: ");
            str.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            str.Append("Order status: ");
            str.AppendLine(Status.ToString());
            str.Append("Client: ");
            str.AppendLine(Client.ToString());
            str.AppendLine("Order items:");

            foreach (OrderItem item in ListItem)
            {
                str.Append(item.Product.Name + ", ");
                str.Append($"${item.Price}, ");
                str.Append($"Quatity: ");
                str.Append(item.Quantity + ", ");
                str.Append("Subtotal: ");
                str.AppendLine($"${item.SubTotal().ToString("F2")}");
                str.Append("Total price: ");
                str.AppendLine($"${Total().ToString("F2")}");
            }
            return str.ToString();
            
        }

    }
}
