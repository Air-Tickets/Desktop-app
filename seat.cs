using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_app
{
    public class seat
    {
        public string SeatName { get; set; }
        public bool IsTaken { get; set; }
        public bool IsNotTaken { get; set; }
        public seat(string seatName, bool isTaken)
        {
            SeatName = seatName;
            IsTaken = isTaken;
            IsNotTaken = !isTaken;
        }
    }
}
