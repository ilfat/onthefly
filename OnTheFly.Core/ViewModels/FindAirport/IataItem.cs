using OnTheFly.Core.Api;

namespace OnTheFly.Core.ViewModels
{
    public class IataItem
    {
        public Direction Direction { get; protected set; }

        public IataItem(Direction direction)
        {
            this.Direction = direction;
        }
        public string Content => string.Format("{0}, {1}, {2}", Direction.Iata, Direction.Name, Direction.Country);
        public string Code => Direction.Iata;
    }
}