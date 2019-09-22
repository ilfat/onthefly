using OnTheFly.Core.Api;
using System.Globalization;

namespace OnTheFly.Core.ViewModels.FindTickets
{
    public class TicketItem
    {
        public TicketItem(PricesResponse price)
        {
            this.Price = price;
        }
        public string Depart => string.Format("{0} {1}", strings.depart_date, Price.DepartDate);
        public string Return => string.Format("{0} {1}", strings.return_date, Price.ReturnDate);

        public string Cost => double.Parse(Price.Value, CultureInfo.InvariantCulture).ToString("C2");
        public string City => Price.Destination;
        public PricesResponse Price { get; private set; }
    }
}
