using Model;

namespace RPRENTAL.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Room>? ROOM_LIST { get; set; }
        public DateOnly CHECKIN_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly CHECKOUT_DATE { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int NO_OF_STAY { get; set; }
    }
}
